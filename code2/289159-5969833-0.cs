    public class MyObject : IEquatable<MyObject>
    {
        public int ObjectID {get;set;}
        public string Prop1 {get;set;}
        public bool Equals(MyObject other)
        {
            if (other == null) return false;
            else return this.ObjectID.Equals(other.ObjectID); 
        }
        public override int GetHashCode()
        {
            return this.ObjectID.GetHashCode();
        }
    }
