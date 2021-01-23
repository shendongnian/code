    public class ExtraProperty
    {
        public string Name { get; set; }
        public string Expression { get; set; }
    }
    /// <summary>
    /// Creates a string on the form "new (property1, property2, ..., expression1 as extraproperty1, ... )
    /// </summary>
    /// <param name="t"></param>
    /// <param name="extraProperties"></param>
    /// <returns></returns>
    public string CreateSelectClauseWithProperty(Type objecType, ExtraProperty[] extraProperties)
    {
        string ret = "new(";
        bool notFirst = false;
        System.Reflection.PropertyInfo[] typeProps = objecType.GetProperties();
        // Equivalent of "Select objectType.*"
        foreach (System.Reflection.PropertyInfo p in typeProps)
        {
            if (notFirst)
                ret += ",";
            else
                notFirst = true;
            ret += p.Name;
        }
        // Equivalent of "expression1 as name1, expression2 as name2, ..." - giving the extra columns
        foreach (ExtraProperty ep in extraProperties)
        {
            if (notFirst)
                ret += ",";
            else
                notFirst = true;
            ret += ep.Expression + " as " + ep.Name;
        }
        return ret + ")";
    }
