    class Color
    {
        // ...
    }
    class SomeClass
    {
        string SomeMethod(string s, bool reformulate)
        {
            OtherClass o = new OtherClass(s);
            string result = Frob(o);
            // o is elegible for garbage collection here
            if (reformulate)
            {
                Reformulate();
            }
            return result;
        }
        string Frob(OtherClass o)
        {
            string result = FrobColor(o.GetEffectiveColor());
            // o is elegible for garbage collection here
            return result;
        }
        string FrobColor(Color color)
        {
            return color.ToString();
        }
        void Reformulate()
        {
            // ...
        }
    }
    class OtherClass
    {
        public OtherClass(string s)
        {
            _ = s;
        }
        OtherClass Parent {get; set;}
        Color Color {get; set;}
        public Color GetEffectiveColor()
        {
            Color color = this.Color;
            for (OtherClass o = this.Parent; o != null; o = o.Parent)
            {
                color = BlendColors(color, o.Color);
            }
            // this is elegible for garbage collection here
            return color;
        }
        static Color BlendColors(Color left, Color right)
        {
            _ = right;
            return left;
        }
    }
