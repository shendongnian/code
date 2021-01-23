    class root
    {
        public root()
        {
        }
        public studentinfo studentinfo { get; set; }
    }
    class studentinfo
    {
        public studentinfo()
        {
            subject = new List<subject>();
        }
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public address address;
        public List<subject> subject;
    }
    class address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
    class subject
    {
        public string name { get; set; }
        public int marks { get; set; }
        public string grade { get; set; }
    }
