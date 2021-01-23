    [Serializable]
    public class MySerializableGenericClass<T>
    {
       public T Item { get; set; }
       static MySerializableGenericClass()   
       {
          ConstrainType(typeof(T));
       }
       static void ConstrainType(Type type)
       {
          if(!type.IsSerializable)
             throw new InvalidOperationException("Provided type is not serializable");
       }
    }
