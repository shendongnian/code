     SPList list = web.Lists[strListName];
     string strRet="";
     foreach (SPContentType spct in list.ContentTypes)
                    {
                        strRet += "<strong>Content Type: </strong>" + spct.Name + ", <strong>Fields</strong>: <br />";
                        foreach (SPField field in spct.Fields)
                        {
    
                            if (strFieldInfo != "")
                            {
                                strFieldInfo += ", ";
                            }
    
                            strFieldInfo += "\"" + field.StaticName + "\"";
                        }
                        strRet += strFieldInfo + "<br />-----<br />";
                    }
