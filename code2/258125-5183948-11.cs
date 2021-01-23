    public class Foo
    {
        public string Name { get; set; }
    
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
    
            // If parameter cannot be cast to Point return false.
            Foo p = obj as Foo;
            if ((System.Object)p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return (Name == p.Name);
        }
    
        public bool Equals(Foo p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return (Name == p.Name);
        }
    
        public static bool operator ==(Foo f1, Foo f2)
        {
            return f1.Equals(f2);
        }
    
        public static bool operator !=(Foo f1, Foo f2)
        {
            return !f1.Equals(f2);
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
