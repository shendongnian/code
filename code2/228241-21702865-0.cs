        public string GetCheckBoxExportValue(AcroFields fields, string cbFieldName)
        {
            AcroFields.Item item = fields.GetFieldItem(cbFieldName);
            if (item.values.Count > 0)
            {
                PdfDictionary valueDict = item.values[0] as PdfDictionary;
                PdfDictionary appDict = valueDict.GetAsDict(PdfName.AP);
                if (appDict != null)
                {
                    PdfDictionary normalApp = appDict.GetAsDict(PdfName.N);
                    foreach (PdfName curKey in normalApp.Keys)
                    {
                        if (!PdfName.OFF.Equals(curKey))
                        {
                            // string will have a leading '/' character
                            return curKey.ToString(); 
                        }
                    }
                }
                PdfName curVal = valueDict.GetAsName(PdfName.AS);
                if (curVal != null)
                {
                    return curVal.ToString();
                }
            }
            return null;
        }
