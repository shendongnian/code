        public class Relation
        {
            public Int32 SourceId { get; set; }
            public Int32 TargetId { get; set; }
        }
        public Int32?[] FindRelation(Relation[] relations)
        {
            List<Int32?> sourceIds = new List<int?>;
            var countOfTargets = relations.Select(x => x.TargetId).Distinct().Count();
            var relationsGroupedBySource = relations.GroupBy(x => x.SourceId);
            foreach (var group in relationsGroupedBySource)
            {
                var distinctGroup = group.Distinct();
                if (distinctGroup.Count() == countOfTargets)
                {
                    sourceIds.Add(distinctGroup.Select(x => x.SourceId).First());
                }
            }
            return sourceIds.ToArray();
        }
      public void Test()
      {
         var sourceIds = FindRelation(relations);
      }
