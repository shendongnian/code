    using System;
    using System.Runtime.InteropServices;
    public static object GetObjectFromBytes(byte[] buffer, Type objType)
    {
        object obj = null;
        if ((buffer != null) && (buffer.Length > 0))
        {
            IntPtr ptrObj = IntPtr.Zero;
            try
            {
                int objSize = Marshal.SizeOf(objType);
                if (objSize > 0)
                {
                    if (buffer.Length < objSize)
                        throw new Exception(String.Format("Buffer smaller than needed for creation of object of type {0}", objType));
                    ptrObj = Marshal.AllocHGlobal(objSize);
                    if (ptrObj != IntPtr.Zero)
                    {
                        Marshal.Copy(buffer, 0, ptrObj, objSize);
                        obj = Marshal.PtrToStructure(ptrObj, objType);
                    }
                    else
                        throw new Exception(String.Format("Couldn't allocate memory to create object of type {0}", objType));
                }
            }
            finally
            {
                if (ptrObj != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptrObj);
            }
        }
        return obj;
    }
