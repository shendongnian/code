    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.ComponentModel;
    
    namespace MemoryMappedFileTests
    {
      class Program
      {
        static void Main(string[] args)
        {
          IntPtr ptr = IntPtr.Zero;
          try
          {
            // Allocate and Commit the memory directly.
            ptr = VirtualAllocEx(
              Process.GetCurrentProcess().Handle, 
              IntPtr.Zero, 
              new IntPtr(0xD0000000L), 
              AllocationType.Commit | AllocationType.Reserve, 
              MemoryProtection.ReadWrite);
            if (ptr == IntPtr.Zero)
            {
              throw new Win32Exception(Marshal.GetLastWin32Error());
            }
    
            // Query some information about the allocation, used for testing.
            MEMORY_BASIC_INFORMATION mbi = new MEMORY_BASIC_INFORMATION();
            IntPtr result = VirtualQueryEx(
              Process.GetCurrentProcess().Handle, 
              ptr, 
              out mbi, 
              new IntPtr(Marshal.SizeOf(mbi)));
            if (result == IntPtr.Zero)
            {
              throw new Win32Exception(Marshal.GetLastWin32Error());
            }
    
            // Use unsafe code to get a pointer to the unmanaged memory. 
            // This requires compiling with /unsafe option.
            unsafe
            {
              // Pointer to the allocated memory
              byte* pBytes = (byte*)ptr.ToPointer();
    
              // Create Read/Write stream to access the memory.
              UnmanagedMemoryStream stm = new UnmanagedMemoryStream(
                pBytes, 
                mbi.RegionSize.ToInt64(), 
                mbi.RegionSize.ToInt64(), 
                FileAccess.ReadWrite);
    
              // Create a StreamWriter to write to the unmanaged memory.
              StreamWriter sw = new StreamWriter(stm);
              sw.Write("Everything seems to be working!\r\n");
              sw.Flush();
    
              // Reset the stream position and create a reader to check that the 
              // data was written correctly.
              stm.Position = 0;
              StreamReader rd = new StreamReader(stm);
              Console.WriteLine(rd.ReadLine());
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.ToString());
          }
          finally
          {
            if (ptr != IntPtr.Zero)
            {
              VirtualFreeEx(
                Process.GetCurrentProcess().Handle, 
                ptr, 
                IntPtr.Zero, 
                FreeType.Release);
            }
          }
    
          Console.ReadKey();
        }
    
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(
          IntPtr hProcess, 
          IntPtr lpAddress,
          IntPtr dwSize, 
          AllocationType dwAllocationType, 
          MemoryProtection flProtect);
    
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(
          IntPtr hProcess, 
          IntPtr lpAddress, 
          IntPtr dwSize, 
          FreeType dwFreeType);
    
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualQueryEx(
          IntPtr hProcess, 
          IntPtr lpAddress, 
          out MEMORY_BASIC_INFORMATION lpBuffer, 
          IntPtr dwLength);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
          public IntPtr BaseAddress;
          public IntPtr AllocationBase;
          public int AllocationProtect;
          public IntPtr RegionSize;
          public int State;
          public int Protect;
          public int Type;
        }
    
        [Flags]
        public enum AllocationType
        {
          Commit = 0x1000,
          Reserve = 0x2000,
          Decommit = 0x4000,
          Release = 0x8000,
          Reset = 0x80000,
          Physical = 0x400000,
          TopDown = 0x100000,
          WriteWatch = 0x200000,
          LargePages = 0x20000000
        }
    
        [Flags]
        public enum MemoryProtection
        {
          Execute = 0x10,
          ExecuteRead = 0x20,
          ExecuteReadWrite = 0x40,
          ExecuteWriteCopy = 0x80,
          NoAccess = 0x01,
          ReadOnly = 0x02,
          ReadWrite = 0x04,
          WriteCopy = 0x08,
          GuardModifierflag = 0x100,
          NoCacheModifierflag = 0x200,
          WriteCombineModifierflag = 0x400
        }
    
        [Flags]
        public enum FreeType
        {
          Decommit = 0x4000,
          Release = 0x8000
        }
      }
    }
