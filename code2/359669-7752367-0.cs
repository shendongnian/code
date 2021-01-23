        static void Main(string[] args)
        {
            var test = new List<string[]>() {
                                                new String[3] { "a", "b", "b" }, 
                                                new String[3] { "a", "c", "c" }, 
                                                new String[3] { "b", "b", "c" }, 
                                                new String[3] { "a", "d", "d" }, 
                                                new String[3] { "x", "y", "z" } 
                                            };
            var foundFirst = test.Find(i => i[0].Equals("a"));
            var foundAll = test.Where(i => i[0].Equals("a"));
        }
