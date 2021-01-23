       abstract public class Property
        {
            private readonly String _name;
            public Property(String propertyName)
            {
                _name = propertyName;
            }
            public String Name
            {
                get { return _name; }
            }
            abstract public override String ToString();
        }
        public class StringProperty : Property
        {
            private readonly dynamic _value; // different properties for different types 
            public StringProperty(String propertyName, dynamic value)
                : base(propertyName)
            {
                this._value = value;
            }
            public dynamic Value // different signature for different properties 
            {
                get { return _value; }
            }
            public override String ToString()
            {
                return base.Name + ": " + _value;
            }
        }
        static void Main(string[] args)
        {
            StringProperty sp = new StringProperty("A double", 3.444);
            StringProperty sp2 = new StringProperty("My int", 4343);
            StringProperty sp3 = new StringProperty("My directory", new  DirectoryInfo("Some directory"));
            StringProperty sp4 = new StringProperty("My null", null);
            Console.WriteLine(sp);
            Console.WriteLine(sp2);
            Console.WriteLine(sp3);
            Console.WriteLine(sp4);
        }
    }
