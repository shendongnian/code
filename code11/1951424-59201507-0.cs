        public abstract class Error<ConcreteError>
            where ConcreteError : Error<ConcreteError>, new()
        {
            protected Error() { }
            public string Message { get; protected set; }
            public static ConcreteError Because(string msg)
            {
                return new ConcreteError() { Message = msg };
            }
        }
        public class MyError : Error<MyError> { }
        public class OtherError : Error<OtherError> { }
       
        static void Main(string[] args)
        {
            MyError myError = MyError.Because("Something went wrong");
            OtherError myError2 = OtherError.Because("Something else went wrong");
        }
