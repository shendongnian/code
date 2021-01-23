                List<int> ints = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            Expression<Func<IEnumerable<int>, IEnumerable<int>>> expr = x=> x.Where(y=> y>6);
            Expression<Func<IEnumerable<int>, IEnumerable<IGrouping<bool,int>>>> expr1 = x => x.GroupBy(y => y > 6);
            // first expression
            var bobs = expr.Compile()(ints);
            foreach(var bob in bobs)
            {
                Console.WriteLine(bob);
            }
            // second expression
            var bobs1 = expr1.Compile()(ints);
            int counter = 0;
            foreach (IGrouping<bool, int> bob in bobs1)
            {
                Console.WriteLine("group " + counter++ + " values :");
                foreach (var t in bob)
                {
                    Console.WriteLine(t);
                }
            }
