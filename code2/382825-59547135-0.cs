    public static string ObjectToString(object obj)
    {
        var sb = new StringBuilder();
        try
        {
            sb.AppendLine(obj.GetType().Name);
            foreach (var prop in obj.GetType().GetProperties())
            {
                sb.AppendLine(string.Format("{0} Property Name: {1}; Value: [{2}]; Type: {3}", "--->", prop.Name, prop.GetValue(obj, null)?.ToString(), prop.PropertyType?.FullName));
            }
            foreach (var fld in obj.GetType().GetFields())
            {
                if (!fld.FieldType.Namespace.Equals("System", StringComparison.InvariantCultureIgnoreCase) && fld.GetValue(obj) != null)
                {
                    ObjectToString(fld.GetValue(obj), sb);
                }
                else
                {
                    sb.AppendLine(string.Format("{0} Field Name: {1}; Value: [{2}]; Type: {3}", "--->", fld.Name, fld.GetValue(obj)?.ToString(), fld.FieldType?.FullName));
                }
            }
        }
        catch (Exception ex)
        {
            sb.AppendLine("---> Exception in ObjectToString: " + ex.Message);
        }
        return sb.ToString();
    }
    public static string ObjectToString(object obj, StringBuilder sb, int depth = 1)
    {
        try
        {
            sb.AppendLine(string.Format("{0}{1} {2}", (depth==2?"----":""),"--->", obj.GetType().Name));
            foreach (var prop in obj.GetType().GetProperties())
            {
                sb.AppendLine(string.Format("{0} Property Name: {1}; Value: [{2}]; Type: {3}", "------->", prop.Name, prop.GetValue(obj, null)?.ToString(), prop.PropertyType?.FullName));
            }
            foreach (var fld in obj.GetType().GetFields())
            {
                //we want to avoid stake overflow and go only one more depth
                if (!fld.FieldType.Namespace.Equals("System", StringComparison.InvariantCultureIgnoreCase) && fld.GetValue(obj) != null && depth < 2)
                {
                    ObjectToString(fld.GetValue(obj), sb, 2);
                }
                else
                {
                    sb.AppendLine(string.Format("{0} Field Name: {1}; Value: [{2}]; Type: {3}", "------->", fld.Name, fld.GetValue(obj)?.ToString(), fld.FieldType?.FullName));
                }
            }
        }
        catch (Exception ex)
        {
            sb.AppendLine("-------> Exception in ObjectToString: depth(" + depth + ") " + ex.Message);
        }
        return sb.ToString();
    }
