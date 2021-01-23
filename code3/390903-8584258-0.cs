    var r1 = Enumerable.Range(0, multiPointer.GetLength(0))
                        .Select(i => new
                            {
                                Index = i,
                                Col1 = multiPointer[i, 0],
                                Col2 = multiPointer[i, 1],
                                Col3 = multiPointer[i, 2],
                                Col4 = multiPointer[i, 3]
                            });
            var r2 = stuff.Select((v, i) => new { Index = i, Value = v });
            var result = from p in r1
                         from q in r2
                         where p.Index == q.Index
                         select new
                         {
                             Stuff = q.Value,
                             Col1 = p.Col1,
                             Col2 = p.Col2,
                             Col3 = p.Col3,
                             Col4 = p.Col4,
                         };
            foreach (var r in result)
            {
                Console.WriteLine(string.Format("{0} : {1} , {2} , {3} , {4}", r.Stuff, r.Col1, r.Col2, r.Col3, r.Col4));
            }
            Console.Read();
