    public class MyClass
    {
        public static void Main()
        {
            var result = new MyClass().TrySomeFunction();
            if (result.Succeeded)
            {
                // use it
                MyReturningResultType resultValue = result.GetResultValue();
            }
            else
            {
                // use message
                string message = result.ResultMessage;
            }
        }
        Result<MyReturningResultType> TrySomeFunction()
        {
            try
            {
                MyReturningResultType value = CalculateIt();
                return new Result<MyReturningResultType>(value) { Succeeded = true };
            }
            catch (Exception exception)
            {
                return new Result<MyReturningResultType>(default(MyReturningResultType))
                {
                    Succeeded = false,
                    ResultMessage = exception.Message
                };
            }
        }
    }
    public class Result<T>
    {
        public Result(T resultValue) { this.ResultValue = resultValue; }
        public bool Succeeded { get; set; }
        public string ResultMessage { get; set; }
        public T GetResultValue()
        {
            if (ResultValue is T)
            {
                return (T)this.ResultValue;
            }
            return default(T);
        }
        private T ResultValue;
    }
