     internal static void UpdateCustomPropertyValue(DocX document, string customPropertyName, string customPropertyValue)
            {
    			foreach (XElement e in document.mainDoc.Descendants(XName.Get("instrText", w.NamespaceName))) 
    			{
    				string attr_value = e.Value.Replace(" ", string.Empty).Trim();
    				string match_value = string.Format(@"DOCPROPERTY  {0}  \* MERGEFORMAT", customPropertyName).Replace(" ", string.Empty);
    
    				if (attr_value.Equals(match_value, StringComparison.CurrentCultureIgnoreCase))
    				{
    					XNode node = e.Parent.NextNode;
    					bool found = false;
    					while (true)
    					{
    						if (node.NodeType == XmlNodeType.Element)
    						{
    							var ele = node as XElement;
    							var match = ele.Descendants(XName.Get("t", w.NamespaceName));
    							if (match.Count() > 0)
    							{
    								if (!found)
    								{
    									match.First().Value = customPropertyValue;
    									found = true;
    								}
    								else
    								{
    									ele.RemoveNodes();
    								}
    							}
    							else
    							{
    								match = ele.Descendants(XName.Get("fldChar", w.NamespaceName));
    								if (match.Count() > 0)
    								{
    									var endMatch = match.First().Attribute(XName.Get("fldCharType", w.NamespaceName));
    									if (endMatch != null && endMatch.Value == "end")
    									{
    										break;
    									}
    								}
    							}
    						}
    						node = node.NextNode;
    					}
    				}
    			}
    			 
    			foreach (XElement e in document.mainDoc.Descendants(XName.Get("fldSimple", w.NamespaceName))) 
                {
    				string attr_value = e.Attribute(XName.Get("instr", w.NamespaceName)).Value.Replace(" ", string.Empty).Trim();
                    string match_value = string.Format(@"DOCPROPERTY  {0}  \* MERGEFORMAT", customPropertyName).Replace(" ", string.Empty);
    
                    if (attr_value.Equals(match_value, StringComparison.CurrentCultureIgnoreCase))
                    {
                        XElement firstRun = e.Element(w + "r");
                        XElement firstText = firstRun.Element(w + "t");
                        XElement rPr = firstText.Element(w + "rPr");
    
                        // Delete everything and insert updated text value
                        e.RemoveNodes();
    
                        XElement t = new XElement(w + "t", rPr, customPropertyValue);
                        Novacode.Text.PreserveSpace(t);
                        e.Add(new XElement(firstRun.Name, firstRun.Attributes(), firstRun.Element(XName.Get("rPr", w.NamespaceName)), t));
                    }
                }
    }
 
