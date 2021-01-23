    private class ValidValue
    {
        public bool Valid { get; private set; }
        public int Value { get; private set; }
        public ValidValue(bool valid, int value)
        { 
            Valid = valid;
            Value = value;
        }
        //etc., but this seems a bit too much like hard work, and you don't get 
        // equality for free as you would with Tuple, (if you need it)
