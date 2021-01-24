    public partial class enterprisePersonTel
{
    private string teltypeField;
    private string valueField;
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string teltype
    {
        get
        {
            return this.teltypeField;
        }
        set
        {
            this.teltypeField = value;
        }
    }
    /// <remarks/>
    **[System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }**
