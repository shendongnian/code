    public class incrementable
    {
        public string s; // For storing string value that holds the number
        public incrementable(string _s)
        {
            s = _s;
        }
        public static explicit operator incrementable(string tmp)
        {
            return new incrementable(tmp);
        }
        public static implicit operator string(incrementable tmp)
        {
            return tmp.s;
        }
        public static incrementable operator +(incrementable str, int inc) // This will work flawlessly like `somestring = (incrementable)somestring + 1`
            => new incrementable((Convert.ToInt32(str.s) + inc).ToString());
        public static incrementable operator ++(incrementable str) // Unfortunately won't work, see below
            => new incrementable((Convert.ToInt32(str.s) + 1).ToString());
    }
