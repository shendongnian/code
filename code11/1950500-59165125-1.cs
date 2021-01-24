                    String setor = "";
                    String localServico = "";
                    String confeccao = "";
                    if (listItem["Setor"] != null && listItem["Setor"].ToString() == "Microsoft.SharePoint.Client.FieldLookupValue")
                    {
                        setor = (listItem["Setor"] as FieldLookupValue).LookupValue;
                    }
                    else if (listItem["Setor"] != null && listItem["Setor"].ToString() != "Microsoft.SharePoint.Client.FieldLookupValue")
                    {
                        setor = listItem["Setor"].ToString();
                    }
                    if (listItem["LocalServico"] != null && listItem["LocalServico"].ToString() == "Microsoft.SharePoint.Client.FieldLookupValue")
                    {
                        localServico = (listItem["LocalServico"] as FieldLookupValue).LookupValue;
                    }
                    else if (listItem["LocalServico"] != null && listItem["LocalServico"].ToString() != "Microsoft.SharePoint.Client.FieldLookupValue")
                    {
                        localServico = listItem["LocalServico"].ToString();
                    }
                    if (listItem["Confeccao"] != null && listItem["Confeccao"].ToString() == "Microsoft.SharePoint.Client.FieldLookupValue")
                    {
                        confeccao = (listItem["Confeccao"] as FieldLookupValue).LookupValue;
                    }
                    else if (listItem["Confeccao"] != null && listItem["Confeccao"].ToString() != "Microsoft.SharePoint.Client.FieldLookupValue")
                    {
                        confeccao = listItem["Confeccao"].ToString();
                    }
                    Console.WriteLine(setor + "   " + "|" + "   "
                        + localServico + "   " + "|" + "   "
                        + confeccao);
