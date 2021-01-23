    public class MyObject : IEquatable<MyObject>
    {
        public int ID {get;set;}
        public string Name {get;set;}
        public override bool Equals(object o)
        {
            var other = o as MyObject;
            return other == null ? false : other.ID == ID;
        }    
        public bool Equals(MyObject o)
        {
            return o.Name == Name;
        } 
    }
