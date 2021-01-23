    class Sample
    {
        private readonly int _intField;
        public int IntProperty
        {
            get { return _intField; }
        }
        void setupStuff(ref int intField, int newValue)
        {
            intField = newValue;
        }
        public Sample(string theIntAsString)
        {
            int i = int.Parse(theIntAsString);
            setupStuff(ref _intField,i);
        }
        public Sample(int theInt)
        {
            setupStuff(ref _intField, theInt);
        }
    }
