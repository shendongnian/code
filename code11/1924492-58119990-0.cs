// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class steps
{
    private stepsStep[] stepField;
    private steps comprefField;
    private int idField;
    private int lastField;
    private int refField;
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("step")]
    public stepsStep[] step
    {
        get
        {
            return this.stepField;
        }
        set
        {
            this.stepField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("compref")]
    public steps compref
    {
        get
        {
            return this.comprefField;
        }
        set
        {
            this.comprefField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int last
    {
        get
        {
            return this.lastField;
        }
        set
        {
            this.lastField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int @ref
    {
        get
        {
            return this.refField;
        }
        set
        {
            this.refField = value;
        }
    }
}
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class stepsStep
{
    private stepsStepParameterizedString[] parameterizedStringField;
    private object descriptionField;
    private byte idField;
    private string typeField;
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("parameterizedString")]
    public stepsStepParameterizedString[] parameterizedString
    {
        get
        {
            return this.parameterizedStringField;
        }
        set
        {
            this.parameterizedStringField = value;
        }
    }
    /// <remarks/>
    public object description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }
}
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class stepsStepParameterizedString
{
    private bool isformattedField;
    private string valueField;
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool isformatted
    {
        get
        {
            return this.isformattedField;
        }
        set
        {
            this.isformattedField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
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
    }
}
The xml content is not really readable ;)
Thanks for your help.
