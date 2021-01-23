       static class extentions
    {
        public static List<Varience> DetailedCompare(this object val1, object val2)
        {
            List<Varience> variences = new List<Varience>();
            FieldInfo[] fi = val1.GetType().GetFields();
            foreach (FieldInfo f in fi)
            {
                Varience v = new Varience();
                v.valA = f.GetValue(val1);
                v.valB = f.GetValue(val2);
                if (!v.valA.Equals(v.valB))
                    variences.Add(v);
            }
            return variences;
        }
    }
    class Varience
    {
        string _prop;
        public string Prop
        {
            get { return _prop; }
            set { _prop = value; }
        }
        object _valA;
        public object valA
        {
            get { return _valA; }
            set { _valA = value; }
        }
        object _valB;
        public object valB
        {
            get { return _valB; }
            set { _valB = value; }
        }
    }
