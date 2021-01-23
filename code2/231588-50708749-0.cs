        public class urlmonMimeDetect
        {
            [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
            private extern static System.UInt32 FindMimeFromData(
                System.UInt32 pBC,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
                [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
                System.UInt32 cbSize,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
                System.UInt32 dwMimeFlags,
                out System.UInt32 ppwzMimeOut,
                System.UInt32 dwReserverd
            );
            public static string GetMimeFromFile(Stream fs)
            {
                byte[] buffer = new byte[256];
                fs.Read(buffer, 0, 256);
                try
                {
                    System.UInt32 mimetype;
                    FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                    System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                    string mime = Marshal.PtrToStringUni(mimeTypePtr);
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                    return mime;
                }
                catch (Exception e)
                {
                    return "unknown/unknown";
                }
            }
        }
