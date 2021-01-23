    public class MyClass
    {
        private string pickedProperty = null;
        private object member1;
        private object member2;
        public object Property1 
        {
            get { return this.member1; }
            set 
            {
                if (this.pickedProperty == null)
                    this.pickedProperty = "Property1";
                if (this.pickedProperty == "Property1")
                    this.member1 = value;
            }
        }
        public object Property2 
        {
            get { return this.member2; }
            set
            {
                if (this.pickedProperty == null)
                    this.pickedProperty = "Property2";
                if (this.pickedProperty == "Property2")
                    this.member1 = value;
            }
        }
    }
