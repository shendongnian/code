    enum DBType
    {
        Int,
        Bool,
    }
    class DBProperties
    {
        public DBType DBType;
    }
    class Program
    {
        static void Main(string[] args)
        {
            DBType d = (DBType)2;
            DBProperties p = new DBProperties();
            p.DBType = d;
            Console.WriteLine((int)p.DBType); //outputs 2
            Console.ReadLine();
        }
    }
