    public class MyObject
    {
        public string attrb1 { get; set; }
        public string attrb2 { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as MyObject;
            return other != null && other.attrb1 == attrb1 && other.attrb2 == attrb2;
        }
        public override int GetHashCode()
        {
            return (attrb1 + attrb2).GetHashCode();
        }
    }
