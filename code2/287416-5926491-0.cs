    public string[] ShowHierarchy(int employeeId)
    {
        using (var db = new YourDataContext("yourConStr"))
        {
            return ShowHierarchyRecursive(db, employeeId, 1)
                .ToArray();
        }
    }
    private IEnumerable<string> ShowHierarchyRecursive(
        YourDataContext db, int employeeId, int level)
    {
        // get the name of employeeId from db
        // yield return that name
        // get the list of people managed by that employeeId
        
        // foreach employee in that list,
        // call the ShowHierarchyRecursive, and
        // foreach item in the returned list yield return
        // that item.
    }
