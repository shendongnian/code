    namespace BarStuff {
      //the serializer is perfectly happy with me
      public class DummyBar{}
      //the serializer doesn't like me
      public class Bar{
      ...
      }
      ...
    }
    using BarStuff;
    namespace FooStuff {
      [XmlInclude(typeof(DummyBar))]
      public class Foo {
        public T GetBar<TBar, T>( string key ) where TBar : Bar<T> {
          ...
        }
      }
    
