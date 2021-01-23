    abstract class Base<T, U>
    {
      private U _obj;
      public Base(string xml)
      {
        _obj = (new Deserializer<T>()).XML2Object(xml);
      }
      
      public abstract void process();
      protected abstract String getResponse();
    }
