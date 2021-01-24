    class Device
    {
        public int ID { get; set; }
        public string PatName { get; set; }
        public string[] Array
        {
            get
            {
                return new string[] { ID.ToString(), PatName };
            }
        }
    }
