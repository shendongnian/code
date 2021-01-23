        static void Main(string[] args)
        {
            Person j = new John();
            var t = j.GetType();
            Type genType = Type.MakeGenericType(new Type[] { typeof(List<>) });
            IList x =  (IList) Activator.CreateInstance(genType, t);        
        }
