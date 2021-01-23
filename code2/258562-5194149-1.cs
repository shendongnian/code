    class Program
    {
        static void Main(string[] args)
        {
            // The operation retrieved from the db
            string operation = "Average";
            // The items on which the operations should be performed
            decimal[] items = { 22m, 55m, 77m };
            object result = typeof(UserOperations).GetMethod(operation).Invoke(null, new object[] { items });
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
