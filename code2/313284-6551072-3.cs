    public class Program
        {
            static void Main(string[] args)
            {
                Customer c = new Customer();
                c.SomeMethod();
            }
        }
    
        [AddMethodAspect]
        public class Customer
        {
            public void SomeMethod() { }
    
        }
    
        [Serializable]
        public class AddMethodAspect : InstanceLevelAspect
        {
            [IntroduceMember(OverrideAction = MemberOverrideAction.OverrideOrFail)]
            public void SomeMethod()
            {
                Console.WriteLine("Hello");
            }
        }
