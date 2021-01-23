    namespace BarStuff {
      public class DummyBar{}
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
    
