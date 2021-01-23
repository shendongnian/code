    public class MyService
    {
        private List<MyObject> _protectedObjects = new List<MyObject>();
    
        public MyObject GetItem(int id)
        {
            return (MyObject)_protectedObjects.First(i => i.Id == id).Clone();
        }
    }
    
    public class MyObject : ICloneable
    {
         //[...]
         public object Clone()
         {
             return MemberwiseClone();
         }
    }
