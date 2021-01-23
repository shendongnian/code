    class Program
    {
        static void Main(string[] args)
        {
            CatOwner Bob = new CatOwner();
            Console.WriteLine(((Cat)Bob).Cry);
            Console.ReadKey();
        }
    }
    interface ICry
    {
        string Cry { get; }
    }
    class Cat : ICry
    {
        public string Cry { get { return "Meow !"; } }
    }
    class CatOwner
    {
        private Cat _Cryer;
        public CatOwner()
        {
            _Cryer = new Cat();
        }
        public static implicit operator Cat(CatOwner po)
        {
            return po._Cryer;
        }
    }
