    public static bool EmptyOrEqual(this string one, string another)
    {
        return string.IsNullOrEmpty(one) || string.IsNullOrEmpty(another) || one.Equals(another);
    }
    bIsMatch = emp.EmpName.EmptyOrEqual(criteria.EmpName) 
                && emp.OfficeName.EmptyOrEqual(criteria.OfficeName);
