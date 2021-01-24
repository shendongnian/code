    public interface IIvalueIEnum<T>
    where T:IValue
    {
        IEnumerable<T> list {get;}
    }
    public class Collection:IIvalueIEnum<Value>
    {
        public IEnumerable<Value> list =>ActualList;
        public List<Value> ActualList{get;set;}
    }
