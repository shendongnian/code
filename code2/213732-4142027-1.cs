    public static bool EmptyOrEquals(this string one, string another)
    {
        return string.IsNullOrEmpty(another) || one.Equals(another);
    }
    bIsMatch = emp.EmpName.EmptyOrEquals(criteria.EmpName) 
                && emp.OfficeName.EmptyOrEquals(criteria.OfficeName);
