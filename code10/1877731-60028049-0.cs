    namespace Models
    {
        public class Person : MarshalByRefObject
        {
            public void SayHelloFromAppDomain()
            {
                Console.WriteLine($"Hello from {AppDomain.CurrentDomain.FriendlyName}");
            }
        }
    }
