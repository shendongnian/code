                        if (attributes == null)
                        {
                            attributes = new List<OpenXmlAttribute>();
                        }
                         //Here I created the hyperlink
                        string xx = @"HYPERLINK(""[KillFile2.xlsx]Sheet1!A10"", ""Go to 
                        Sheet1 > A10"")";
                        attributes.Add(new OpenXmlAttribute("t", null, "inlineStr"));
                        writer.WriteStartElement(new Cell(), attributes);
                        //Here hyperlink added to cell formula
                        writer.WriteElement(new CellFormula(xx));
                        writer.WriteEndElement();
  
