    public class XmlReaderBinder
        {
            public static void BindDropDown(ComboBox dd, string elementName, string nodeNameValue,
                              string nodeNameText, string xmlPath)
            {
                HttpContext context = HttpContext.Current;
                XmlTextReader reader = null;
                ArrayList lstItems = new ArrayList();
                string val = String.Empty;
                string txt = String.Empty;
                bool inTarget = false;
                try
                {
                    reader = new XmlTextReader(xmlPath);
                    //Allow for object to object comparison rather than string comparison
                    object target = reader.NameTable.Add(elementName);
                    object targetVal = reader.NameTable.Add(nodeNameValue);
                    object targetTxt = reader.NameTable.Add(nodeNameText);
                    //Read through the XML stream and find proper tokens
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            //Check attribute names
                            if (reader.Name.Equals(target))
                            {
                                inTarget = true;
                                //Get attribute values (if any)
                                if (reader.HasAttributes)
                                {
                                    if (reader.MoveToAttribute(nodeNameValue))
                                    {
                                        val = reader.Value;
                                        reader.MoveToElement();
                                    }
                                    if (reader.MoveToAttribute(nodeNameText))
                                    {
                                        txt = reader.Value;
                                        reader.MoveToElement();
                                    }
                                }
                                if (val == "" || txt == "") val = txt = String.Empty;
                                if (val != String.Empty && txt != String.Empty)
                                {
                                    ListItem item = new ListItem(txt, val);
                                    lstItems.Add(item);
                                    //Attribute values override any child nodes values
                                    //so if we match on attributes then don't look at any 
                                    //child nodes
                                    inTarget = false;
                                    val = txt = String.Empty;
                                }
                            }
                            else if (inTarget)
                            {  //Check for child nodes that match
                                if (reader.Name.Equals(targetVal))
                                {
                                    val = reader.ReadString();
                                    if (val == "") val = String.Empty;
                                }
                                if (reader.Name.Equals(targetTxt))
                                {
                                    txt = reader.ReadString();
                                    if (txt == "") txt = String.Empty;
                                }
                                if (val != String.Empty && txt != String.Empty)
                                {
                                    ListItem item = new ListItem(txt, val);
                                    lstItems.Add(item);
                                    val = txt = String.Empty;
                                }
                            }
                        }
                        if (reader.NodeType == XmlNodeType.EndElement || reader.IsEmptyElement)
                        {
                            if (reader.Name.Equals(target))
                            {
                                inTarget = false;
                            }
                        }
    
                    }
                    if (lstItems.Count > 0)
                    {
                        foreach (ListItem item in lstItems)
                        {
                            dd.Items.Add(item);
                        }
    
                    }
                    else
                    {
                        ListItem item = new ListItem("No Data Available", "");
                        dd.Items.Add(item);
                    }
                    lstItems.Clear();
                }
                catch (Exception exp)
                {
                    context.Response.Write(exp.Message);
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
    
        }
