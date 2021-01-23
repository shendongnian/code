    [Serializable]
    public class Matrix<T>
    {
      // ...
    }
    
    public static class Helper
    {
      public static T DeepCopy<T>(T obj)
      {
        using (var stream = new MemoryStream())
        {
          var formatter = new BinaryFormatter();
          formatter.Serialize(stream, obj);
          stream.Position = 0;
          return (T) formatter.Deserialize(stream);
        }
      }
    }
