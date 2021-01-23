    for (var i = new Frob(0, "track_{0}"); i < 100; i++)
    {
        Console.WriteLine(i.ValueDescription);
    }
    struct Frob
    {
        public int Value { get; private set; }
        public string ValueDescription { get; private set; }
        private string _format;
        public Frob(int value, string format)
            : this()
        {
            Value = value;
            ValueDescription = string.Format(format, value);
            _format = format;
        }
        public static Frob operator ++(Frob value)
        {
            return new Frob(value.Value + 1, value._format);
        }
        public static Frob operator --(Frob value)
        {
            return new Frob(value.Value - 1, value._format);
        }
        public static implicit operator int(Frob value)
        {
            return value.Value;
        }
        public static implicit operator string(Frob value)
        {
            return value.ValueDescription;
        }
        public override bool Equals(object obj)
        {
            if (obj is Frob)
            {
                return ((Frob)obj).Value == Value;
            }
            else if (obj is string)
            {
                return ((string)obj) == ValueDescription;
            }
            else if (obj is int)
            {
                return ((int)obj) == Value;
            }
            else
            {
                return base.Equals(obj);
            }
        }
        public override int GetHashCode()
        {
            return Value;
        }
        public override string ToString()
        {
            return ValueDescription;
        }
    }
