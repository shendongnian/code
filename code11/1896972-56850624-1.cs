    private static void GetDependents(IList<int> dependencies, int seed)
    {
        foreach (var dependent in dependencies)
        {
            var dependentDept = departments.Where(d => d.Id == dependent).FirstOrDefault();
            if (dependentDept.Dependencies.Count > 0)
            {
                if (dependencies.Contains(seed) || dependentDept.HasCircularReferences)
                {
                    SetCircularReferenceFlag(seed, true);
                    break;
                }
                GetDependents(dependentDept.Dependencies, seed);
            }
            else
            {
                SetCircularReferenceFlag(seed, false);
                break;
            }
        }
    }
