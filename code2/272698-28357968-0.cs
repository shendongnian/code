    public static System.Web.UI.Control CloneControl(Control c)
                {
                    Type type = c.GetType();
                    var clone = (0 == type.GetConstructors().Length) ? new Control() : Activator.CreateInstance(type) as Control;
                    if (c is HtmlControl)
                    {
                        clone.ID = c.ID;
                        AttributeCollection attributeCollection = ((HtmlControl)c).Attributes;
                        System.Collections.ICollection keys = attributeCollection.Keys;
                        foreach (string key in keys)
                        {
                            ((HtmlControl)c).Attributes.Add(key, (string)attributeCollection[key]);
                        }
                    }else if(c is System.Web.UI.LiteralControl){
                        clone = new System.Web.UI.LiteralControl(((System.Web.UI.LiteralControl)(c)).Text);
                    }
                    else
                    {
                        PropertyInfo[] properties = c.GetType().GetProperties();
                        foreach (PropertyInfo p in properties)
                        {
                            // "InnerHtml/Text" are generated on the fly, so skip them. "Page" can be ignored, because it will be set when control is added to a Page.
                            if (p.Name != "InnerHtml" && p.Name != "InnerText" && p.Name != "Page" && p.CanRead && p.CanWrite)
                            {
                                try
                                {
                                    ParameterInfo[] indexParameters = p.GetIndexParameters();
                                    p.SetValue(clone, p.GetValue(c, indexParameters), indexParameters);
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    int cControlsCount = c.Controls.Count;
                    for (int i = 0; i < cControlsCount; ++i)
                    {
                        clone.Controls.Add(CloneControl(c.Controls[i]));
                    }
                    return clone;
                }
