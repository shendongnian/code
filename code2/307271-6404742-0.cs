    namespace ClassLibrary1
    {
        public class Class1 : MarshalByRefObject
        {
            public void Go()
            {
                Console.WriteLine("My AppDomain's FriendlyName is: {0}", AppDomain.CurrentDomain.FriendlyName);
            }
        }
    }
