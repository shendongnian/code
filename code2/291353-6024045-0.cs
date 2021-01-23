    [XmlRoot(Check)]
    public class Check    
    {  
        [XmlElement("LNItem")]
        List<LNItem> LNItems { get; set; }
    }
    
    [XmlRoot(LNItem)]
    public class LNItem
    {
        [XmlAttribute("amt")]
        AmtType Amt { get; set; }
    }
