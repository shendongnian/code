        public ScrollableExampleConstructor()
        {
            _si = new SCROLLINFO();
            _si.fMask = (uint) ScrollInfoMask.SIF_ALL;
            _si.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(_si);
        }
