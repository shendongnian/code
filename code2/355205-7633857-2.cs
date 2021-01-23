    class CommonImplementation
    {
        public static readonly CommonImplementation Instance = new CommonImplementation();
        private CommonImplementation() { }
        public void SomeMethod(string someArg, bool isServerCall)
        {
            if (isServerCall)
            {
                Console.WriteLine("Remote! {0}", someArg);
            }
            else
            {
                Console.WriteLine("Local! {0}", someArg);
            }
        }
    }
    // These two classes are the facade.
    public class LocalClass : MarshalByRefObject
    {
        public virtual void SomeMethod(string someArg)
        {
            CommonImplementation.Instance.SomeMethod(someArg, false);
        }
    }
    class RemoteClass : LocalClass
    {
        public override void SomeMethod(string someArg)
        {
            CommonImplementation.Instance.SomeMethod(someArg, true);
        }
    }
