        async Task MoveContentFast(IStorageFolder source, IStorageFolder destination)
        {
            await Task.Run(() =>
            {
                MoveContextImpl(new DirectoryInfo(source.Path), destination);
            });
        }
        private void MoveContextImpl(DirectoryInfo sourceFolderInfo, IStorageFolder destination)
        {
            var tasks = new List<Task>();
            var destinationAccess = destination as IStorageFolderHandleAccess;
            foreach (var item in sourceFolderInfo.EnumerateFileSystemInfos())
            {
                if ((item.Attributes & System.IO.FileAttributes.Directory) != 0)
                {
                    tasks.Add(destination.CreateFolderAsync(item.Name, CreationCollisionOption.ReplaceExisting).AsTask().ContinueWith((destinationSubFolder) =>
                    {
                        MoveContextImpl((DirectoryInfo)item, destinationSubFolder.Result);
                    }));
                }
                else
                {
                    if (destinationAccess == null)
                    {
                        // Slower, pre 14393 OS build path
                        tasks.Add(WindowsRuntimeStorageExtensions.OpenStreamForWriteAsync(destination, item.Name, CreationCollisionOption.ReplaceExisting).ContinueWith((openTask) =>
                        {
                            using (var stream = openTask.Result)
                            {
                                var sourceBytes = File.ReadAllBytes(item.FullName);
                                stream.Write(sourceBytes, 0, sourceBytes.Length);
                            }
                            File.Delete(item.FullName);
                        }));
                    }
                    else
                    {
                        int hr = destinationAccess.Create(item.Name, HANDLE_CREATION_OPTIONS.CREATE_ALWAYS, HANDLE_ACCESS_OPTIONS.WRITE, HANDLE_SHARING_OPTIONS.SHARE_NONE, HANDLE_OPTIONS.NONE, IntPtr.Zero, out SafeFileHandle file);
                        if (hr < 0)
                            Marshal.ThrowExceptionForHR(hr);
                        using (file)
                        {
                            using (var stream = new FileStream(file, FileAccess.Write))
                            {
                                var sourceBytes = File.ReadAllBytes(item.FullName);
                                stream.Write(sourceBytes, 0, sourceBytes.Length);
                            }
                        }
                        File.Delete(item.FullName);
                    }
                }
            }
            Task.WaitAll(tasks.ToArray());
        }
        [ComImport]
        [Guid("DF19938F-5462-48A0-BE65-D2A3271A08D6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IStorageFolderHandleAccess
        {
            [PreserveSig]
            int Create(
                [MarshalAs(UnmanagedType.LPWStr)] string fileName,
                HANDLE_CREATION_OPTIONS creationOptions,
                HANDLE_ACCESS_OPTIONS accessOptions,
                HANDLE_SHARING_OPTIONS sharingOptions,
                HANDLE_OPTIONS options,
                IntPtr oplockBreakingHandler,
                out SafeFileHandle interopHandle); // using Microsoft.Win32.SafeHandles
        }
        internal enum HANDLE_CREATION_OPTIONS : uint
        {
            CREATE_NEW = 0x1,
            CREATE_ALWAYS = 0x2,
            OPEN_EXISTING = 0x3,
            OPEN_ALWAYS = 0x4,
            TRUNCATE_EXISTING = 0x5,
        }
        [Flags]
        internal enum HANDLE_ACCESS_OPTIONS : uint
        {
            NONE = 0,
            READ_ATTRIBUTES = 0x80,
            // 0x120089
            READ = SYNCHRONIZE | READ_CONTROL | READ_ATTRIBUTES | FILE_READ_EA | FILE_READ_DATA,
            // 0x120116
            WRITE = SYNCHRONIZE | READ_CONTROL | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | FILE_WRITE_DATA,
            DELETE = 0x10000,
            READ_CONTROL = 0x00020000,
            SYNCHRONIZE = 0x00100000,
            FILE_READ_DATA = 0x00000001,
            FILE_WRITE_DATA = 0x00000002,
            FILE_APPEND_DATA = 0x00000004,
            FILE_READ_EA = 0x00000008,
            FILE_WRITE_EA = 0x00000010,
            FILE_EXECUTE = 0x00000020,
            FILE_WRITE_ATTRIBUTES = 0x00000100,
        }
        [Flags]
        internal enum HANDLE_SHARING_OPTIONS : uint
        {
            SHARE_NONE = 0,
            SHARE_READ = 0x1,
            SHARE_WRITE = 0x2,
            SHARE_DELETE = 0x4
        }
        [Flags]
        internal enum HANDLE_OPTIONS : uint
        {
            NONE = 0,
            OPEN_REQUIRING_OPLOCK = 0x40000,
            DELETE_ON_CLOSE = 0x4000000,
            SEQUENTIAL_SCAN = 0x8000000,
            RANDOM_ACCESS = 0x10000000,
            NO_BUFFERING = 0x20000000,
            OVERLAPPED = 0x40000000,
            WRITE_THROUGH = 0x80000000
        }
