       public class MyGenericClass<T> where T : IComparable 
       {
        T[] Data;
        public void AddData(T[] values) 
        {
            Data = values;
            var list = Data.ToList();
            object compareWith = new object();
            compareWith = 3;
            int count = list.Where(a=>a.CompareTo(compareWith) == 0).Count();
        }
      }
