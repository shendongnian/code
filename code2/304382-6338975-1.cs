    class status : Usage
    {
        public string strng;
        public status()
        {
            this.strng = "Hello";
        }
        public override string getinfo()
        {
            return strng;
        }
        public override void add(Usage u)
        {
        }
    }
