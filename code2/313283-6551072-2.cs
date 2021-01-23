    public class Program
        {
            static void Main(string[] args)
            {
                Customer c = new Customer();
                var cc = Post.Cast<Customer, ISomething>(c);
    
                cc.SomeMethod();
            }
        }
    
        public interface ISomething
        {
            void SomeMethod();
        }
    
        [AddMethodAspect]
        public class Customer
        {
            
        }
    
        [Serializable]
        [IntroduceInterface(typeof(ISomething))]
        public class AddMethodAspect : InstanceLevelAspect, ISomething
        {
    
            #region ISomething Members
    
            public void SomeMethod()
            {
                Console.WriteLine("Hello");
            }
    
            #endregion
        }
