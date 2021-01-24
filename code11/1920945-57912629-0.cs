        [StructLayout(LayoutKind.Sequential)]
        public struct Item
        {
            [MarshalAs(UnmanagedType.AnsiBStr)]
            public string id;
            [MarshalAs(UnmanagedType.AnsiBStr)]
            public string name;
            public uint variation;
            public uint category;
            public uint quality;
        }
        public class Inventory {
            [DllImport("stuff")]
            [System.Security.SecurityCritical]
            private static extern void ffi_sort_inventory(uint length, IntPtr items);
            public void sort_inventory()
            {
                 Item[] items = null;
                 IntPtr itemsPtr =  IntPtr.Zero;
                Marshal.StructureToPtr(items, itemsPtr, true);
                ffi_sort_inventory((uint) items.Length, itemsPtr);
            } 
        }
