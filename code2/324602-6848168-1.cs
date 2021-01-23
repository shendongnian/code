    public class AnotherChildClass : BaseClass
    {
        private readonly BaseClass _bling;
    
        public AnotherChildClass(BaseClass bling)
        {
            _bling = bling;
        }
    
        public override void SomeMethod()
        {
            _bling.SomeMethod();
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
