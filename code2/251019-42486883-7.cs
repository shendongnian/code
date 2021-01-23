    static void Main(string[] args)
        {
            var lst = new List<Test>();
            lst.Add(new Test("coucou1", "kiki1"));
            lst.Add(new Test("coucou2", "kiki2"));
            lst.Add(new Test("coucou3", "kiki3"));
            lst.Add(new Test("coucou4", "
            lst.ForEach(i => Console.WriteLine(i.GetAttributeName<Test>(t => t.Name)+";"+i.GetAttributeName<Test>(t=>t.t2)));
          
        }
