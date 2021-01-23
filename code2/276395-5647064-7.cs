    class SomeClass
    {
        private readonly YourFormClass form;
        public SomeClass(YourFormClass form)
        {
            this.form = form;
        }
    
        private void SomeMethodDoingStuffWithText()
        {
            string firstName = form.FirstName;
            form.FirstName = "some name";
        }
    }
