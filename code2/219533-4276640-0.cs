    StringBuilder csv = String.Empty;
    PropertyInfo[] ps this.GetType().GetProperties();
    foreach (PropertyInfo p in ps)
    {
        csv.Append(p.GetValue(this, null);
        csv.Append(",");
    }
