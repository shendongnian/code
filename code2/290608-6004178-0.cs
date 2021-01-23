        public void Method()
        {
            //Stuff that should always happen in base class
            OnMethod();
        }
        protected virtual void OnMethod()
        {
            //Default base class implementation that derived class can either override or extend
        }
