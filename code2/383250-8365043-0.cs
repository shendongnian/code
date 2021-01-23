    public static class StructOrganizer
    {
        public static IEnumerable<Tuple<Decimal, Decimal, IEnumerable<MyStruct>>> OrganizeWithoutGaps(this IEnumerable<MyStruct> someStructs)
        {
            var someStructsAsList = someStructs.ToList();
            var lastValuesSeen = new Tuple<Decimal, Decimal>(someStructsAsList[0].A, someStructsAsList[0].B);
            var currentList = new List<MyStruct>();
            return Enumerable
                .Range(0, someStructsAsList.Count)
                .ToList()
                .Select(i =>
                            {
                                var current = someStructsAsList[i];
                                if (lastValuesSeen.Equals(new Tuple<Decimal, Decimal>(current.A, current.B)))
                                    currentList.Add(current);
                                else
                                {
                                    lastValuesSeen = new Tuple<decimal, decimal>(current.A, current.B);
                                    var oldList = currentList;
                                    currentList = new List<MyStruct>(new [] { current });
                                    return new Tuple<decimal, decimal, IEnumerable<MyStruct>>(lastValuesSeen.Item1, lastValuesSeen.Item2, oldList);
                                }
                                return null;
                            })
                .Where(i => i != null);
        }
        // To Test:
        public static void Test()
        {
            var r = new Random();
            var sampleData = Enumerable.Range(1, 31).Select(i => new MyStruct {A = r.Next(0, 2), B = r.Next(0, 2), date = new DateTime(2011, 12, i)}).OrderBy(s => s.date).ToList();
            var sortedData = sampleData.OrganizeWithoutGaps();
            Console.Out.WriteLine("Sample Data:");
            sampleData.ForEach(s => Console.Out.WriteLine("{0} = ({1}, {2})", s.date, s.A, s.B));
            Console.Out.WriteLine("Output:");
            sortedData.ToList().ForEach(s => Console.Out.WriteLine("({0}, {1}) = {2}", s.Item1, s.Item2, String.Join(", ", s.Item3.Select(st => st.date))));
        }
    }
