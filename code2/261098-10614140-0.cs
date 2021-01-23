    public class First
    {
        public Second sec;
        public First(Second aSec)
        {
            this.sec = aSec;
        }
        public void change()
        {
            this.sec.Name = "PUli";
        }
    }
    public class Second
    {
        private string _name;
        public Second()
        {
            Name = "SUli";
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    class Program
    {
        static void Main(String[] args)
        {
            Second sec = new Second();
            First f = new First(sec);
            Console.WriteLine(sec.Name);
            f.change();
            Console.WriteLine(sec.Name);
        }
    }
