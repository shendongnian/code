    class Program
    {
        static void Main(string[] args)
        {
            string str = "&";
            using (var context = new DataClasses1DataContext())
            {
                var clients = context.Clients.Where(x => x.Code.Contains(str.ToUpper()));
                clients = clients.Take(5);
                Console.WriteLine(clients.Count());
            }          
        }
    }
