    public class MyObject
    {
        public string attrb1 { get; set; }
        public string attrb2 { get; set; }
        public bool Equals(MyObject other)
        {
            return other != null && other.attrb1 == attrb1 && other.attrb2 == attrb2;
        }
        public override bool Equals(object other)
        {
            return Equals(other as MyObject);
        }
        public override int GetHashCode()
        {
            return attrb1.GetHashCode() ^ attrb2.GetHashCode();
        }
    }
