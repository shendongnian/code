    class InteropBitmapSyncWrapper
    {
    
        public InteropBitmapSyncWrapper(InteropBitmap wrappedBitmap)
        {
            WrappedBitmap = wrappedBitmap;
            this.Lock = new Object();
        }
    
        public InteropBitmap WrappedBitmap
        {
            get;
            set;
        }
    
        public Object Lock
        {
            get;
            private set;
        }
    }
