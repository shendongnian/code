    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    
    namespace MmbpTree
    {
        public unsafe sealed class GrowableMemoryMappedFile : IDisposable
        {
    
            private const int AllocationGranularity = 64 * 1024;
    
            private class MemoryMappedArea
            {
                public MemoryMappedFile Mmf;
                public byte* Address;
                public long Size;
            }
    
    
            private FileStream fs;
    
            private List<MemoryMappedArea> areas = new List<MemoryMappedArea>();
            private long[] offsets;
            private byte*[] addresses;
            public long Length
            {
                get {
                    CheckDisposed();
                    return fs.Length;
                }
            }
    
            public GrowableMemoryMappedFile(string filePath, long initialFileSize)
            {
                if (initialFileSize <= 0 || initialFileSize % AllocationGranularity != 0)
                {
                    throw new ArgumentException("The initial file size must be a multiple of 64Kb and grater than zero");
                }
                bool existingFile = File.Exists(filePath);
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                if (existingFile)
                {
                    if (fs.Length <=  0 || fs.Length % AllocationGranularity != 0)
                    {
                        throw new ArgumentException("Invalid file. Its lenght must be a multiple of 64Kb and greater than zero");
                    }
                }
                else
                { 
                    fs.SetLength(initialFileSize);
                }
                CreateFirstArea();
            }
    
            private void CreateFirstArea()
            {
                var mmf = MemoryMappedFile.CreateFromFile(fs, null, fs.Length, MemoryMappedFileAccess.ReadWrite,  null, HandleInheritability.None, true);
                var address = Win32FileMapping.MapViewOfFileEx(mmf.SafeMemoryMappedFileHandle.DangerousGetHandle(), 
                    Win32FileMapping.FileMapAccess.Read | Win32FileMapping.FileMapAccess.Write,
                    0, 0, new UIntPtr((ulong) fs.Length), null);
                if (address == null) throw new Win32Exception();
    
                var area = new MemoryMappedArea
                {
                    Address = address,
                    Mmf = mmf,
                    Size = fs.Length
                };
                areas.Add(area);
    
                addresses = new byte*[] { address };
                offsets = new long[] { 0 };
    
            }
    
    
            public void Grow(long bytesToGrow)
            {
                CheckDisposed();
                if (bytesToGrow <= 0 || bytesToGrow % AllocationGranularity != 0)  {
                    throw new ArgumentException("The growth must be a multiple of 64Kb and greater than zero");
                }
                long offset = fs.Length;
                fs.SetLength(fs.Length + bytesToGrow);
                var mmf = MemoryMappedFile.CreateFromFile(fs, null, fs.Length, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.None, true);
                uint* offsetPointer = (uint*)&offset;
                var lastArea = areas[areas.Count - 1];
                byte* desiredAddress = lastArea.Address + lastArea.Size;
                var address = Win32FileMapping.MapViewOfFileEx(mmf.SafeMemoryMappedFileHandle.DangerousGetHandle(), 
                    Win32FileMapping.FileMapAccess.Read | Win32FileMapping.FileMapAccess.Write,
                    offsetPointer[1], offsetPointer[0], new UIntPtr((ulong)bytesToGrow), desiredAddress);
                if (address == null) {
                    address = Win32FileMapping.MapViewOfFileEx(mmf.SafeMemoryMappedFileHandle.DangerousGetHandle(),
                       Win32FileMapping.FileMapAccess.Read | Win32FileMapping.FileMapAccess.Write,
                       offsetPointer[1], offsetPointer[0], new UIntPtr((ulong)bytesToGrow), null);
                }
                if (address == null) throw new Win32Exception();
                var area = new MemoryMappedArea {
                    Address = address,
                    Mmf = mmf,
                    Size = bytesToGrow
                };
                areas.Add(area);
                if (desiredAddress != address) {
                    offsets = offsets.Add(offset);
                    addresses = addresses.Add(address);
                }
            }
    
            public byte* GetPointer(long offset)
            {
                CheckDisposed();
                int i = offsets.Length;
                if (i <= 128) // linear search is more efficient for small arrays. Experiments show 140 as the cutpoint on x64 and 100 on x86.
                {
                    while (--i > 0 && offsets[i] > offset);
                }
                else // binary search is more efficient for large arrays
                {
                    i = Array.BinarySearch<long>(offsets, offset);
                    if (i < 0) i = ~i - 1;
                }
                return addresses[i] + offset - offsets[i];
            }
    
            private bool isDisposed;
    
            public void Dispose()
            {
                if (isDisposed) return;
                isDisposed = true;
                foreach (var a in this.areas)
                {
                    Win32FileMapping.UnmapViewOfFile(a.Address);
                    a.Mmf.Dispose();
                }
                fs.Dispose();
                areas.Clear();
            }
    
            private void CheckDisposed()
            {
                if (isDisposed) throw new ObjectDisposedException(this.GetType().Name);
            }
    
            public void Flush()
            {
                CheckDisposed();
                foreach (var area in areas)
                {
                    if (!Win32FileMapping.FlushViewOfFile(area.Address, new IntPtr(area.Size))) {
                        throw new Win32Exception();
                    }
                }
                fs.Flush(true);
            }
        }
    }
