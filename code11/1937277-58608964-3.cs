    class Program
    {
        public static void Main(string[] args)
        {
            var integerHandler = new IntegerHandler();
            var stringHandler = new StringHandler();
            ValidateHandler(integerHandler);
            ValidateHandler(stringHandler);
        }
        //  This method must require T to be IModel because IAddHandler<T> requires 
        //  T to be IModel.
        public static void ValidateHandler<T>(IAddHandler<T> handler) where T : IModel
        {
            handler.GetData();
            var result = handler.Add();
            //  IModel inherits from IResult. Hence, anything that implements IModel 
            //  must implement IResult. So this is an implicit cast, even though IResult 
            //  is implemented explicitly. 
            WriteResults(result);
        }
        //  The parameter here could be IModel instead, but maybe there are other non-model 
        //  classes that implement IResult.
        public static void WriteResults(IResult result)
        {
            Console.WriteLine(result.Result);
        }
    }
