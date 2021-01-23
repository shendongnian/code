    class StringTuple
    {
        public string StringA { get; set; }
        public string StringB { get; set; }
        public override bool Equals(object obj)
        {
            var stringTuple = obj as StringTuple;
            if (stringTuple == null)
                return false;
            return (StringA.Equals(stringTuple.StringA) && StringB.Equals(stringTuple.StringB)) ||
                (StringA.Equals(stringTuple.StringB) && StringB.Equals(stringTuple.StringA));
        }
        public override int GetHashCode()
        {
            // Order of operands is irrelevant when using *
            return StringA.GetHashCode() * StringB.GetHashCode();
        }
    }
