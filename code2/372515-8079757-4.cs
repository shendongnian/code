    [Serializable]
    [XmlRoot("LEFTSECTION")]
    public class NewClass
    {
        [XmlElement("DATA")]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Data;
    
        [XmlElement("FONTNAME")]
        public string FontName;
    
        [XmlElement("FONTSTYLE")]
        public string FontStyle;
    
        [XmlElement("FONTSIZE")]
        public int FontSize;
    
        [XmlElement("TEXTCOLOR")]
        public int TextColor;
    
        [XmlElement("STRIKEOUT")]
        public int Strikeout;
    
        [XmlElement("UNDERLINE")]
        public int Underline;
    
        [XmlElement("BORDER")]
        public int Border;
    
        [XmlElement("IMAGE")]
        public int Image;
    
        [XmlElement("IMAGENAME")]
        public string ImageName;
        
        [System.ComponentModel.DefaultValue(0)]
        [XmlElement("ALIGNMENT")]
        public int Alignment;
    
        [XmlElement("SECTIONHEIGHT")]
        public double SectionHeight;
    
        [XmlElement("SECTIONWIDTH")]
        public double SectionWidth;
    }
