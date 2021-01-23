    private PropertyInfo[] _PropertyInfos = null;
    public override string ToString()
    {
        if(_PropertyInfos == null)
            _PropertyInfos = this.GetType().GetProperties();
        var sb = new StringBuilder();
        foreach (var info in _PropertyInfos)
        {
            sb.AppendLine(info.Name + ": " + info.GetValue(this, null).ToString());
        }
        return sb.ToString();
    }
