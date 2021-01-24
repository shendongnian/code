                    String setor = "";
                    String localServico = "";
                    String confeccao = "";
                    if (listItem["Setor"] != null)
                    {
                        setor = (listItem["Setor"] as FieldLookupValue).LookupValue;
                    }
                    if (listItem["LocalServico"] != null)
                    {
                        localServico = (listItem["LocalServico"] as FieldLookupValue).LookupValue;
                    }
                    Console.WriteLine(setor + "   " + "|" + "   "
                        + localServico + "   " + "|" + "   "
                        + listItem["Confeccao"]);
