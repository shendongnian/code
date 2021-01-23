    public static IQueryable<TblProjCd> ByEmployeeId(this IQueryable<TblProjCd> qry, int employeeId)
    {
        //Return the filtered IQueryable object
        return from q in qry
               where q.TblEmployee.Any(p => p.EmployeeId == employeeId)
               select q;
    }
