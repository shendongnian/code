      public class MyClassTestComparer : IEqualityComparer<MyClass> {
        public bool Equals(MyClass x, MyClass y) {
          if (ReferenceEquals(x, y))
            return true;
          else if (null == x || null == y)
            return false;
          return x.Propery1 == y.Property1 && 
                 x.Propery2 == y.Property2 &&
                 x.ProperyN == y.PropertyN; 
        }
        public int GetHashCode(MyClass obj) {
          return obj == null 
            ? 0 
            : obj.Propery1.GetHashCode() ^ obj.Propery2.GetHashCode();
        }
      }
