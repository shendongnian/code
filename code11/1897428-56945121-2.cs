    XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FilePath.XmlBinCode); //load the file
                xmlBinDefinitionModel.EqptID = xmlDocument.DocumentElement.SelectSingleNode("EqptID").InnerText;
                xmlBinDefinitionModel.EquipOpn = xmlDocument.DocumentElement.SelectSingleNode("EquipOpn").InnerText;
                xmlBinDefinitionModel.BinDefinition = new List<BinDefinitionModel>();
                XmlNodeList binCodeList = xmlDocument.GetElementsByTagName("BinCode");
                XmlNodeList binDescriptionList = xmlDocument.GetElementsByTagName("BinDescription");
                XmlNodeList binQualityList = xmlDocument.GetElementsByTagName("BinQuality");
                XmlNodeList pickList = xmlDocument.GetElementsByTagName("Pick");
                XmlNodeList visionStationList = xmlDocument.GetElementsByTagName("VisionStation");
                XmlNodeList visionIOList = xmlDocument.GetElementsByTagName("VisionIO");
                for (int i = 0; i < binCodeList.Count; i++)
                {
                    xmlBinDefinitionModel.BinDefinition.Add(new BinDefinitionModel
                    {
                        BinCode = binCodeList[i].InnerText.Remove(0,2),
                        BinDescription = binDescriptionList[i].InnerText,
                        BinQuality = binQualityList[i].InnerText,
                        Pick = pickList[i].InnerText,
                        VisionStation = visionStationList[i].InnerText,
                        VisionIO = visionStationList[i].InnerText
                    });
                }
