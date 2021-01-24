                using (StreamReader streamreader = new StreamReader(response.GetResponseStream()))
                {
                    string result1 = streamreader.ReadToEnd();
                    MessageBox.Show(result1);
                    xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(result1);
                    XmlNodeList nodeList;
                    if (xmlDocument.DocumentElement.Attributes["xmlns:soapenv"] != null)
                    {
                        string xmlns = xmlDocument.DocumentElement.Attributes["xmlns:soapenv"].Value;
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
                        nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                        nsmgr.AddNamespace("df", "http://schemas.datastream.net/MP_functions/MP0118_GetGridHeaderData_001_Result");
                        
                        nodeList = xmlDocument.SelectNodes("/soapenv:Envelope/soapenv:Body/df:MP0118_GetGridHeaderData_001_Result/df:GRIDRESULT/df:GRID/df:DATA/df:ROW[*]", nsmgr);
                    }
                    else
                    {
                        nodeList = xmlDocument.SelectNodes("/soapenv:Envelope/soapenv:Body/df:MP0118_GetGridHeaderData_001_Result/df:GRIDRESULT/df:GRID/df:DATA/df:ROW[*]");
                    }
                    
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        if (nodeList[i].InnerText.Length > 0)
                        {
                            String ctr_code = nodeList[i].ChildNodes[0].InnerText;
                            String ctr_status = nodeList[i].ChildNodes[1].InnerText;
                            String ctr_org = nodeList[i].ChildNodes[2].InnerText;
                            String ctr_type = nodeList[i].ChildNodes[3].InnerText;
                            String ctr_contactsource = nodeList[i].ChildNodes[4].InnerText;
                            String ctr_created = nodeList[i].ChildNodes[5].InnerText;
                            String ctr_servicecategory = nodeList[i].ChildNodes[6].InnerText;
                            String ctr_serviceproblem = nodeList[i].ChildNodes[7].InnerText;
                            String ctr_object = nodeList[i].ChildNodes[8].InnerText;
                            String ctr_contactinfoid = nodeList[i].ChildNodes[9].InnerText;
                            String ctr_contactnote = nodeList[i].ChildNodes[10].InnerText;
                            String ctr_desc = nodeList[i].ChildNodes[11].InnerText;
                            String ctr_note = nodeList[i].ChildNodes[12].InnerText;
                            String ctr_event = nodeList[i].ChildNodes[13].InnerText;
                            String ctr_createdby = nodeList[i].ChildNodes[14].InnerText;
                            String ctr_mrc = nodeList[i].ChildNodes[15].InnerText;
                           
                        }
                    }               
                }
            }
        }
