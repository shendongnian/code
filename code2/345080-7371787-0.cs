    class Program
    {
        static void Main(string[] args)
        {
            Person j = new John();
            var t = j.GetType();
            Type genType = generic.MakeGenericType(new System.Type[] { typeof(List<>) });
            IList x =  Activator.CreateInstance(genType, t);        
        }
    }
