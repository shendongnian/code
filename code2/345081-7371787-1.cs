    class Program
    {
        static void Main(string[] args)
        {
            Type genType = generic.MakeGenericType(new System.Type[] { typeof(List<>) });
            IList x =  Activator.CreateInstance(genType, typeof(John)); 
        }
    }
