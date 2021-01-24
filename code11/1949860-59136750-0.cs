    public struct ImageInfo
    {
        public IntPtr data; // image data, works
        public int size;    // image data, works
    
        // string
        //public IntPtr barcodeType; // return gibberish
        //public IntPtr barcodeData; // return gibberish
    
        public string barcodeType;
        public string barcodeData;
    }
