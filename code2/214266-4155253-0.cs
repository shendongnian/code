    public class Root
    {
        private string _MyProp;
        public string MyProp 
        {
            get { return _MyProp;}
            set { _MyProp = SetMyProp(value); }
        }
        protected virtual string SetMyProp(string suggestedValue)
        {
            return suggestedValue;
        }
    }
    public class Child
        : Root
    {
        protected override string SetMyProp(string suggestedValue)
        {
            string oReturn = base.SetMyProp(suggestedValue);
            // Do some sort of cleanup here?
            return oReturn;
        }
    }
