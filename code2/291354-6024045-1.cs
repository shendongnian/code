    [XmlRoot(Check)]
    public class Check    
    {  
        [XmlElement("LNItem")]
        public List<LNItem> LNItems { get; set; }
    }
    
    [XmlRoot(LNItem)]
    public class LNItem
    {
        [XmlAttribute("amt")]
        public AmtType Amt { get; set; }
    }
