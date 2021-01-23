       public class XmlSerializableNewClass : IXmlSerializable
        {
            public string Data;
            public string FontName;
            public string FontStyle;
            public int FontSize;
            public int TextColor;
            public int Strikeout;
            public int Underline;
            public int Border;
            public int Image;
            public string ImageName;
            public int Alignment;
            public double SectionHeight;
            public double SectionWidth;
            public string[]elementNames={"DATA", "FONTNAME", "FONTSTYLE","FONTSIZE","TEXTCOLOR","STRIKEOUT", "UNDERLINE", "BORDER", "IMAGE", "IMAGENAME", "ALIGNMENT", "SECTIONHEIGHT", "SECTIONWIDTH"};
            
            #region IXmlSerializable Members
    
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(System.Xml.XmlReader reader)
            {
                //set default values
                Data=string.Empty;
                FontName = string.Empty;
                FontStyle = string.Empty;
                FontSize = 0;
                TextColor = 0;
                Strikeout = 0;
                Underline = 0;
                Border = 0;
                Image = 0;
                ImageName = string.Empty;
                Alignment = 0;
                SectionHeight = 0.0;
                SectionWidth = 0.0;
            
                reader.MoveToContent();
    
                Boolean isEmptyElement= false;
                isEmptyElement = reader.IsEmptyElement;
                reader.ReadStartElement();
                for (int i=0; i< elementNames.Length; i++)
                {
                    isEmptyElement = reader.IsEmptyElement;
                    string s = reader.Name;
                    switch (s)
                    {
                        case "DATA":
                            if (!isEmptyElement)
                            {
                                Data = reader.ReadElementString("DATA");
                            }
                            else
                            {
                                Data = string.Empty;
                                reader.ReadStartElement();
                            }
                            break;
                        case "FONTNAME":
                            if (!isEmptyElement)
                            {
                                FontName = reader.ReadElementString("FONTNAME");
                            }
                            else
                            {
                                FontName = string.Empty;
                                reader.ReadStartElement();
                            }
                            break;
                        case "FONTSTYLE":
                            if (!isEmptyElement)
                            {
                                FontStyle = reader.ReadElementString("FONTSTYLE");
                            }
                            else
                            {
                                FontStyle = string.Empty;
                                reader.ReadStartElement();
                            }
                            break;
                        case "FONTSIZE":
                            if (!isEmptyElement)
                            {
                                FontSize = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                FontSize = 0;
                                reader.ReadEndElement();
                            }
                            break;
                        case "TEXTCOLOR":
                            if (!isEmptyElement)
                            {
                                TextColor = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                TextColor = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "STRIKEOUT":
                            if (!isEmptyElement)
                            {
                                Strikeout = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                Strikeout = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "UNDERLINE":
                            if (!isEmptyElement)
                            {
                                Underline = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                Underline = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "BORDER":
                            if (!isEmptyElement)
                            {
                                Border = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                Border = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "IMAGE":
                            if (!isEmptyElement)
                            {
                                Image = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                Image = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "IMAGENAME":
                            if (!isEmptyElement)
                            {
                                ImageName = reader.ReadElementString("IMAGENAME");
                            }
                            else
                            {
                                ImageName = string.Empty;
                                reader.ReadStartElement();
                            }
                            break;
                        case "ALIGNMENT":
                            if (!isEmptyElement)
                            {
                                Alignment = reader.ReadElementContentAsInt();
                            }
                            else
                            {
                                Alignment = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "SECTIONHEIGHT":
                            if (!isEmptyElement)
                            {
                                SectionHeight = reader.ReadElementContentAsDouble();
                            }
                            else
                            {
                                SectionHeight = 0;
                                reader.ReadStartElement();
                            }
                            break;
                        case "SECTIONWIDTH":
                            if (!isEmptyElement)
                            {
                                SectionWidth = reader.ReadElementContentAsDouble();
                            }
                            else
                            {
                                SectionWidth = 0;
                                reader.ReadEndElement();
                            }
                            break;
                    }
                }
                reader.ReadEndElement();
           }
    
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
