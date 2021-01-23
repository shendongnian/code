    protected string DataRaw
    {
        get
        {
            if (_Data == null)
                return _DataRaw;
            else
                return new XElement("values", from s in Data select new XElement("value", s)).ToString();
        }
        set
        {
            _DataRaw = value;
        }
    }
    private string _DataRaw;
    private string[] _Data;
    public string[] Data
    {
        get
        {
            if (_Data == null)
            {
                _Data = (from elem in XDocument.Parse(_DataRaw).Root.Elements("value")
                         select elem.Value).ToArray();
            }
            return _Data;
        }
        set
        {
            _Data = value;
        }
    }
