    public class AnotherChildClass
    {
        private readonly BaseClass _bling;
        public AnotherChildClass(BaseClass bling)
        {
            _bling = bling;
        }
        public void SomeMethod()
        {
            try
            {
                _bling.SomeMethod();
            }
            catch (Exception)
            {
                //Do nothing...
            }
        }
    }
