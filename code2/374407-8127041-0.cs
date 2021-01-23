    public class Example : XmlElement {
    public string AString {
        get { return GetAttribute("astring"); }
        set { SetAttribute("astring", value); }
    }
    }
