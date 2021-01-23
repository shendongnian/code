    static bool GetIsParent(long idChild, long idParent, IEnumerable<Employee> employees)
    {
        return GetAncestors(idChild, employees).Any(t => t.Id == idParent);
    }
    static IEnumerable<Employee> GetAncestors(long idEmployee, IEnumerable<Employee> employees)
    {
        var employee = employees.SingleOrDefault(e => e.Id == idEmployee);
        if (employee == null)
        {
            yield break;
        }
        while (employee.ParentId.HasValue)
        {
            var parent = employees.SingleOrDefault(e => e.Id == employee.ParentId.Value);
            if (parent == null)
            {
                yield break;
            }
            else
            {
                employee = parent;
                yield return parent;
            }
        }
    }
    var isParent = GetIsParent(3, 1, employees);
