    static void Main(string[] args)
            {
                var one = new MyObject("One", null);
                var two = new MyObject("Two", DateTime.Parse("06-30-06"));
    
                var list = new List<IDated> {one, two};
    
                new Operator().Operate(ref list);
    
                Console.WriteLine(String.Format("Objects in list = {0}\r\nOperation Succeeded: {1}", list.Count.ToString(), (list.Count == 1).ToString()));
                Console.ReadKey();
            }
