        [Test]
        public void Test()
        {
            var xs = new List<X>
                         {
                             new X("1; 2000-1-1; 2019-12-31"),
                             new X("2; 2000-1-1; 2019-12-31"),
                             new X("3; 2000-1-1; 2009-12-31"),
                             new X("3; 2010-1-1; 2019-12-31"),
                             new X("4; 2000-1-1; 2019-12-31"),
                             new X("5; 2000-1-1; 2014-12-31"),
                             new X("5; 2015-1-1; 2019-12-31")
                         };
            var groupedById = (from x in xs
                              group x by x.Id into ids
                              select ids);
            var maxOccurances = groupedById
                .Max(x => x.Count());
            var result = new List<List<X>>();
            for (var i = 0; i < maxOccurances; i++)
            {
                var list = groupedById.Select(idGroup => idGroup.Count() < i
                                                             ? idGroup.ElementAt(i)
                                                             : idGroup.Last())
                    .ToList();
                result.Add(list);
            }
        }
        public class X
        {
            public int Id { get; set; }
            public DateTime DateFrom { get; set; }
            public DateTime DateTo { get; set; }
            public X(string input)
            {
                var splitted = input.Split(';');
                Id = Convert.ToInt32(splitted[0]);
                DateFrom = Convert.ToDateTime(splitted[1]);
                DateTo = Convert.ToDateTime(splitted[2]);
            }
        }
