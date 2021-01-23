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
          bool serializable = type.IsSerializable;
          if(serializable == false)
             throw new InvalidOperationException("Provided type is not serializable");
       }
    }
