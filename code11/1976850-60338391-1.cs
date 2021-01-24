    //Interface declaration
        public interface ITokennization
        {
            object TokenizationClassMethod();
        }
        //Interface Inheritance/Implementation in class 
        public class TokenizationClass : ITokennization
        {
            private static TokenizationClass _singletonInstance;
            private static readonly object padlock = new object();
            //Default constructor
            public TokenizationClass()
            {
            }
            // SingleTon Design Pattern 
            public static TokenizationClass CheckSingleInstance()
            {
                if (_singletonInstance == null)
                {
                    lock (padlock)
                    {
                        //Checks instance each time 
                        if (_singletonInstance == null)
                            //creates  new instance if no instances already created
                            _singletonInstance = new TokenizationClass();
                    }
                }
                return _singletonInstance;
            }
            // Class Method
            public object TokenizationClassMethod()
            {
                throw new NotImplementedException();
            }
        }
