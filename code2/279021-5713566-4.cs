     public class BaseCollection : List<Base>
     {
        public static BaseCollection ToBase<T>(IEnumerable<T> source) where T: Base
        {
           BaseCollection result = new BaseCollection();
           foreach (T item in source)
           {
              result.Add(item);
           }
           return result;
         }
        public static List<T> FromBase<T>(IEnumerable<Base> source) where T: Base
        {
           List<T> result = new List<T>();
           foreach (Base item in source)
           {
              result.Add((T)item);
           }
           return result;
         }
        public static List<T> ChangeType<T, U>(List<U> source) where T: Base where U:Base
        {        
            List<T> result = new List<T>();        
            foreach (U item in source)        
            {           
                result.Add((T)(Base) item);        
            }        
            return result;      
        }  
     }
