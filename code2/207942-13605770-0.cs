    class Sample
    {
        private readonly int _intField;
        public int IntProperty
        {
            get { return _intField; }
        }
        void setupStuff(ref int intField, int newValue)
        {
            //Do some stuff here based upon the necessary initialized variables.
            intField = newValue;
        }
        public Sample(string theIntAsString, bool? doStuff = true)
        {
            //Initialization of some necessary variables.
            //==========================================
            int i = int.Parse(theIntAsString);
            // ................
            // .......................
            //==========================================
            if (!doStuff.HasValue || doStuff.Value == true)
               setupStuff(ref _intField,i);
        }
        public Sample(int theInt): this(theInt, false) //"false" param to avoid setupStuff() being called two times
        {
            setupStuff(ref _intField, theInt);
        }
    }
