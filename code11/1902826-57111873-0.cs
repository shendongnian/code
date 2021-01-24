        private string _seq_string;
        public string SeqString
        {
            get { return _seq_string; }
            set
            {
                _seq_string = value;
                SeqBytes = StringToByteArray(value); 
            }
        }
        public byte[] SeqBytes {  get; set; }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
