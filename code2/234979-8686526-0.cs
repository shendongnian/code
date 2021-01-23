            xmldoc.Load(rdlFile);
            StringBuilder sb=new StringBuilder();
            XmlNode node = xmldoc.GetElementsByTagName("ReportItems")[0];
            XmlNodeList list = node.ChildNodes;
            atributes=new string[node.ChildNodes.Count];
            int  l = 0;
            for (int j = 0; j < node.ChildNodes.Count; j++)
            {
                
                
                if (list[j].Name == "Image")
                {
                    XmlAttributeCollection att = list[j].Attributes;
                    atributes[l] = att[0].Value.ToUpper();
                    
                }
                l++;
            }
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (searchText.Text.ToUpper() == atributes[i])
                {
                    XmlNodeList lastlist = node.ChildNodes;
                    XmlNodeList endlist = lastlist[i].ChildNodes;
                    for (int k = 0; k < endlist.Count; k++)
                    {
                        sb.Append(endlist[k].Name+" - "+ endlist[k].InnerText);
                        sb.Append("\n"+"\n");
                    }
                    
                }
                
            }
