        public BitArray Input { get; set; }
        [DataMember]
        private bool[] _Input {
            get {
                bool[] b = new bool[Input.Length];
                Input.CopyTo(b, 0);
                return b;
            }
            set
            {
                Input = new BitArray(value);
            }
        }    
