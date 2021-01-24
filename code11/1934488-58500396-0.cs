    public static string GetCustomMetaTagId(Document document)
        {
            Microsoft.Office.Core.DocumentProperties prps = (Microsoft.Office.Core.DocumentProperties)document.CustomDocumentProperties;
            
            string customId = "";
            try
            {
                customId  = prps != null && prps["CUSTOM-ID"] != null ? prps["CUSTOM-ID"].Value : "";
            }
            catch (Exception)
            {
            }
            return customId  ;
        }
