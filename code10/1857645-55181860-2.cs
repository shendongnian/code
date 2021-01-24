    public interface IData
    {
        int Value { get; set; }
    }
    
    public interface IDataWithName : IData
    {
        string Name { get; set; }
    }
    
    public interface IDataContainer<T> where T:IData
    {
        IList<T> DataList { get; set; }
    }
    
    public interface IDataWithNameContainer<T> : IDataContainer<T> where T:IDataWithName
    {
        
    }
    
    public static class ExtensionMethod
    {
        public static int CountNumberOfIDataItems<T>(this IDataContainer<T> i) where T:IData
        {
            return i.DataList.Count;
        }
    }
