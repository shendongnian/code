    private static string FormatSqlValue(System.Data.Common.DbParameter prm)
    {
        if (prm.Value == DBNull.Value) return "NULL";
        switch (prm.DbType)
        {
            case System.Data.DbType.Int32: return (prm.Value.ToString());
            case System.Data.DbType.String: return String.Format("'{0}'", ScrubSqlString((string)prm.Value));
            case System.Data.DbType.AnsiString: return String.Format("'{0}'", ScrubSqlString((string)prm.Value));
            case System.Data.DbType.Boolean: return ((bool)prm.Value ? "1" : "0");
            case System.Data.DbType.DateTime: return String.Format("'{0}'", prm.Value.ToString());
            case System.Data.DbType.DateTime2: return String.Format("'{0}'", prm.Value.ToString());
            case System.Data.DbType.Decimal: return (prm.Value.ToString());
            case System.Data.DbType.Guid: return String.Format("'{0}'", prm.Value.ToString());
            case System.Data.DbType.Double: return (prm.Value.ToString());
            case System.Data.DbType.Byte: return (prm.Value.ToString());
            // TODO: more conversions.
            default: return (prm.DbType.ToString());
        }
    }
    
    private static string FormatSqlValue(Type type, object value)
    {
        if (value == null)
            return "NULL";
        // Handle Nullable<T> types:
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            // If the Nullabe<T> value has been found to have !HasValue, return "NULL":
            if (!(bool)type.GetProperty("HasValue").GetValue(value, null))
                return "NULL";
            // Try our best to format the underlying non-nullable value now:
            return FormatSqlValue(type.GetGenericArguments()[0], type.GetProperty("Value").GetValue(value, null));
        }
        if (type == typeof(Int32)) return value.ToString();
        if (type == typeof(String)) return String.Format("'{0}'", ScrubSqlString((string)value));
        if (type == typeof(Boolean)) return ((bool)value ? "1" : "0");
        if (type == typeof(DateTime)) return String.Format("'{0}'", value.ToString());
        if (type == typeof(Decimal)) return (value.ToString());
        if (type == typeof(Guid)) return String.Format("'{0}'", value.ToString());
        if (type == typeof(Double)) return (value.ToString());
        if (type == typeof(Byte)) return (value.ToString());
        // TODO: complete the mapping...
        return value.ToString();
    }
    
    private static string ScrubSqlString(string value)
    {
        StringBuilder sb = new StringBuilder();
        int i = 0;
        while (i < value.Length)
        {
            if (value[i] == '\'')
            {
                sb.Append("\'\'");
                ++i;
            }
            else
            {
                sb.Append(value[i]);
                ++i;
            }
        }
        return sb.ToString();
    }
    
    private static string FormatSqlParameter(System.Data.Common.DbParameter prm)
    {
        StringBuilder sbDecl = new StringBuilder();
        sbDecl.Append(prm.ParameterName);
        sbDecl.Append(' ');
        switch (prm.DbType)
        {
            case System.Data.DbType.Int32: sbDecl.Append("int"); break;
            // SQL does not like defining nvarchar(0).
            case System.Data.DbType.String: sbDecl.AppendFormat("nvarchar({0})", prm.Size == -1 ? "max" : prm.Size == 0 ? "1" : prm.Size.ToString()); break;
            // SQL does not like defining varchar(0).
            case System.Data.DbType.AnsiString: sbDecl.AppendFormat("varchar({0})", prm.Size == -1 ? "max" : prm.Size == 0 ? "1" : prm.Size.ToString()); break;
            case System.Data.DbType.Boolean: sbDecl.Append("bit"); break;
            case System.Data.DbType.DateTime: sbDecl.Append("datetime"); break;
            case System.Data.DbType.DateTime2: sbDecl.Append("datetime2"); break;
            case System.Data.DbType.Decimal: sbDecl.Append("decimal"); break;  // FIXME: no precision info in DbParameter!
            case System.Data.DbType.Guid: sbDecl.Append("uniqueidentifier"); break;
            case System.Data.DbType.Double: sbDecl.Append("double"); break;
            case System.Data.DbType.Byte: sbDecl.Append("tinyint"); break;
            // TODO: more conversions.
            default: sbDecl.Append(prm.DbType.ToString()); break;
        }
        return sbDecl.ToString();
    }
