    public interface MyReference{
        int Id{get;set;}
    }
    public class SimpleReference : MyReference
    {
        public int Id{get;set;}
    }
    public class CompoundReference<T> : MyReference
    {
        public int Id{get;set;}
        public T TValue{get;set;}
    }
    public class ReferenceCollection : KeyedCollection<int, MyReference>
    {
        protected override int GetKeyForItem(MyReference item)
        {
            return item.Id;
        }
    }
