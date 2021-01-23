        class Foo1 
        {
            public int Id;
            public int BarId { get; set; }
        }
        class Bar1
        {
            public int BarId;
            public string Name { get; set; }
        }
        public void TestMultiMapperIsNotConfusedWithUnorderedCols()
        {
            var result = connection.Query<Foo1,Bar1, Tuple<Foo1,Bar1>>("select 1 as Id, 2 as BarId, 3 as BarId, 'a' as Name", (f,b) => Tuple.Create(f,b), splitOn: "BarId").First();
            result.Item1.Id.IsEqualTo(1);
            result.Item1.BarId.IsEqualTo(2);
            result.Item2.BarId.IsEqualTo(3);
            result.Item2.Name.IsEqualTo("a");
            
        }
