    public class Second
    {
        public First f;
        public Second(First f)
        {
            this.f= f;
        }
        public void change()
        {
            this.f.Name = "PUli";
        }
    }
    public class First
    {
        private string _name;
        public First()
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
            First f = new First();
            Second sec = new Second(f);
            Console.WriteLine(f.Name);
            sec.change();
            Console.WriteLine(f.Name);
        }
    }
