    LayoutRenderer.Register("all-event-properties-hstore", e =>
    {
        var sb = new StringBuilder();
        var first = true;
        var fp = e.FormatProvider ?? CultureInfo.InvariantCulture;
        string GetString(object o) =>
            Convert.ToString(o, fp).Replace("\\", "\\\\").Replace("\"", "\\\"");
        foreach (var (key, value) in e.Properties)
        {
            if (first)
                first = false;
            else
                sb.Append(",");
            sb.Append("\"");
            sb.Append(GetString(key));
            sb.Append("\"=>\"");
            sb.Append(GetString(value));
            sb.Append("\"");
        }
        return sb.ToString();
    });
