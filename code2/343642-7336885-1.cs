    public class GeneralObject
    {
        private object someObject;
        public GeneralObject(object initObject)
        {
            this.someObject = initObject;
        }
        //If you want to bind to some text, for example
        public string Text
        {
            get
            {
                //I think you know which objects are coming as input
                if (this.someObject is SpecialClass1)
                    return ((SpecialClass1)this.someObject).SpecialClass1TextProperty;
                if (this.someObject is SpecialClass2)
                    return ((SpecialClass2)this.someObject).SpecialClass2TextProperty;
                //and so on.
            }
        }
    }
