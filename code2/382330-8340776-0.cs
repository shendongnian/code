    delegate void ErrorDelegate(params object[] arrParams);
    class Error
    {
        string ErrorText { get; set; }
        int ErrorCode { get; set; }
        public ErrorDelegate ErrorFunction;
    }
    static class Program
    {
        static List<Error> errorlist = new List<Error>();
        
        static void initList()
        {
            Error err = new Error();
            err.ErrorFunction = MyOverloadedError;
            errorlist.Add(err);
        }
        
        static void MyOverloadedError(params object[] arrObjects)
        {
            Console.WriteLine(arrObjects);
        }
        static void Main(string[] args)
        {
            initList();
            errorlist[0].ErrorFunction("Sometext");     
        }
    }
    
