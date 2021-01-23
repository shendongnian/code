    internal class MyDOClassComparer : MyDOClass,  IEquatable<MyDOClass>, IEqualityComparer<MyDOClass>
        {
            public override int GetHashCode()
            {
                return Id == 0 ? 0 : Id;
            }
    
            public bool Equals(MyDOClass other)
            {
                return this.Id == other.Id;
            }
    
            public bool Equals(MyDOClass x, MyDOClass y)
            {
                return x.Id == y.Id;
            }
    
            public int GetHashCode(MyDOClass obj)
            {
                return Id == 0 ? 0 : Id;
            }
        }
