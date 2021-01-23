    public class Base<T> where T: class
    {
      public   static T Create(byte[] data)
      {
        MemoryStream ms = new MemoryStream(data);
        BinaryFormatter sf = new BinaryFormatter();
        T result = sf.Deserialize(ms) as T;
        ms.Close();
        return result;
      }
    }
    public Derived1 : Base<Derived1>
    {
    }
    public Derived2 : Base<Derived2>
    {
    }
  
