    var plansCommon = planInfoList.Select(p => p.Plans)
                                  .Aggregate<IEnumerable<Plan>>((p1, p2) =>
                                                     p1.Intersect(p2, new PlanComparer()))
                                   .ToList();
    // Implement IEqualityComparer 
    class PlanComparer : IEqualityComparer<Plan>
    {
        public bool Equals(Plan x, Plan y)
        {
            if (x.Start == y.Start &&
                            x.End == y.End)
                return true;
    
            return false;
        }
    
        public int GetHashCode(Plan obj)
        {
            return obj.Start.GetHashCode() ^ obj.End.GetHashCode();
        }
    }
