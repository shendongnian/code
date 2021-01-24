        [Fact]
        public void FindSourcesThatTargetAll()
        {
            var list = new List<Relation>
            {
                new Relation(1, 1), new Relation(1, 2), new Relation(2, 1), new Relation(3, 2)
            };
            var allTargets = list.Select(x => x.TargetId).Distinct().OrderBy(x=>x).ToList();
            var dict = list.GroupBy(x => x.SourceId).ToDictionary(x => x.Key,
                grouping => grouping.Select(y => y.TargetId).Distinct().OrderBy(x=>x).ToList());
            var sourcesThatTargetAll = dict.Where(x => x.Value.Count == allTargets.Count).Select(x => x.Key).ToList();
            
            Assert.Single(sourcesThatTargetAll);
            Assert.Equal(1, sourcesThatTargetAll.First());
        }
Basically, I did:
 1. Find all the targets.
 2. For every source find all targets (distinct is important) and group it by the source in the dictionary (`dict` variable)
 3. From the above dictionary select all source which matches all targets (count in the example is enough, but you can make a more complicated comparison)
