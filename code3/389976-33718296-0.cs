    public partial class MyDOClass :  IEquatable<MyDOClass>
        {
    
            public override int GetHashCode()
            {
                return Id == 0 ? 0 : Id;
            }
    
            public bool Equals(MyDOClass other)
            {
                return this.Id == other.Id;
            }
        }
