    private PropertyInfo[] _PropertyInfos = null;
    public override string ToString()
    {
        if(_PropertyInfos == null)
            _PropertyInfos = this.GetType().GetProperties();
        var sb = new StringBuilder();
        foreach (var info in _PropertyInfos)
        {
            var value = info.GetValue(this, null) ?? "(null)";
            sb.AppendLine(info.Name + ": " + value.ToString());
        }
        return sb.ToString();
    }
