        public static long FileTime2Long(FILETIME ft) {
            uint low = unchecked((uint)ft.dwLowDateTime);
            return (long)ft.dwHighDateTime << 32 | low;
        }
        static void Test() {
            FILETIME ft = new FILETIME();
            ft.dwHighDateTime = 1;
            ft.dwLowDateTime = -1;
            long value = FileTime2Long(ft);
            Debug.Assert(value == 0x1ffffffff);
        }
