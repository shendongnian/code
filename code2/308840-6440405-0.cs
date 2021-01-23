        sb.Append("\"DateSource\" : {");
        string separator = string.Empty;
        foreach (var row in DateSource)
        {
            sb.Append(separator);
            sb.Append("[");
            sb.Append(string.Format("\"RowKey\" : {0},", row.Key));
            sb.Append(string.Format("\"RowData\" : {0}", row.Value));
            sb.Append("]");
            separator = ",";
        }
        sb.Append("}");
