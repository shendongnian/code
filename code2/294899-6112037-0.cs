    [Serializable]
    public class MySerializableClass
    {
       public object Item { get; set; }
    }
    [Serializable]
    public class MySerializableGenericClass<T>
    {
       public T Item { get; set; }
    }
