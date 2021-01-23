    using Newtonsoft.Json;
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList objs = new ArrayList();
            //get the data reader, etc.
            while(o.Read())
            {
                objs.Add(new
                {
                    Id = o["Id"],
                    CN = o["CatName"],
                    Ord = o["Ord"],
                    Icon = o["Icon"]
                });
            }
            //clean up datareader
            Console.WriteLine(JsonConvert.SerializeObject(objs));
            Console.ReadLine();
        }
    }
