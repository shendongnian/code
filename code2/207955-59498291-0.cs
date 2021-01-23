    public class Sample
    {
        static int preprocess(string theIntAsString)
        {
            return preprocess(int.Parse(theIntAsString));
        }
        static int preprocess(int theIntNeedRounding)
        {
            return theIntNeedRounding/100;
        }
        public Sample(string theIntAsString)
        {
            _intField = preprocess(theIntAsString)
        }
        public Sample(int theIntNeedRounding)
        {
            _intField = preprocess(theIntNeedRounding)
        }
        public int IntProperty  => _intField;
    
        private readonly int _intField;
    }
