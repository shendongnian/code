    class MyBase
    {
        public void MyMethod()
        {
            // do something
            OnMyMethod();
            // do something
        }
        protected virtual void OnMyMethod()
        {
        }
    }
