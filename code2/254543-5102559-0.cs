    class StringTuple
    {
        public string StringA { get; set; }
        public string StringB { get; set; }
        public override bool Equals(object obj)
        {
            var stringTuple = obj as StringTuple;
            return (StringA.Equals(stringTuple.StringA) && StringB.Equals(stringTuple.StringB)) ||
                (StringA.Equals(stringTuple.StringB) && StringB.Equals(stringTuple.StringA));
        }
    }
