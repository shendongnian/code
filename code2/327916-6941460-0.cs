    public string xmlString
    {
    get
    {
        var _builder = new StringBuilder();
        var rpt = (IList<Owner>) rptOwners.DataSource; //ADDED A CAST
        IList<string> ownersRepeater = new List<string>();
        foreach (var item in rpt )
        {
            _builder.Append("<Owners>");
            _builder.Append("<Owner>");
            _builder.Append(String.Format("<item>{0}</item>", name));
            _builder.Append(String.Format("<item>{0}</item>", address));
            _builder.Append(String.Format("<item>{0}</item>", age));
            _builder.Append("</Owner>");
            _builder.Append("</Owners>");
        }
        return _builder.ToString();
    }
