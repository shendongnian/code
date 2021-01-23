    class Program
    {
        static void Main(string[] args)
        {
            var service = new MyTypeOfXService();
            var queryById = service.GetTypeOfX((mytype) => mytype.Id == 1);
            var queryByName = service.GetTypeOfX((mytype) => mytype.Name == "MyName");
            var queryByName = service.GetTypeOfX((mytype) => mytype.Name == "MyName" && mytype.Id == 1);
        }
    }
