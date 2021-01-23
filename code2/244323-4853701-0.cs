    class Test
    {
        static void Main()
        {
            dynamic e = new ExpandoObject();
            e.Name = "Hello";
            IDictionary<string, object> dict = (IDictionary<string, object>)e;
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }
            dict.Add("Test", "Something");
            Console.WriteLine(e.Test);
            Console.ReadKey();
        }
    }
