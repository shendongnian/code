    public class A
    {
        //Public version used by calling code.
        public void SomeMethod()
        {
            try
            {
                protectedMethod();
            }
            catch (SomeException exc)
            {
                //handle the exception.
            }
        }
        //Derived classes can override this version, any exception thrown can be handled in SomeMethod.
        protected virtual void protectedMethod()
        {
        }
    }
    public class B : A
    {
        protected override void protectedMethod()
        {
            //Throw your exception here.
        }
    }
