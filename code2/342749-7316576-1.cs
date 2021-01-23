    static bool GetIsDescendant(long idChild, long idAncestor, IEnumerable<Employee> employees)
    {
        return GetAncestors(idChild, employees).Any(t => t.Id == idAncestor);
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
