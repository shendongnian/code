    class JsonRequest
    {
        public string SelectType { get; set; }
        public string Num { get; set; }
        public string Size { get; set; }
        public string Title { get; set; }
        // <serialNumber, Barcode> Assuming this data is linked and SerialNumber is unquie.
        public Dictionary<string, string> ContentField { get; set; }
    }
