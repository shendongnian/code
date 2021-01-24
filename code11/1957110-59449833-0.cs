    public static string ValidateMvpFields(string value1, Dictionary<string, ValueMap> value2)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(value1);
            StringBuilder sb = new StringBuilder();  //Initialize StringBuider
     
            foreach (var item in value2.Keys)
            {
                try
                {
                    var Val1 = xmlDoc.SelectSingleNode(responseParameters[item].XPath).InnerText;
                    var Val2 = responseParameters[item].Value;
                    if (!Val1.Trim().Equals(Val2.Trim()))
                    {
                        var results = ErrorMessage = $"Mvp Field Values Mismatch For Field: {item} Expected:{Val1} Actual:{Val2}";
                        //Append new value every time into string builder
                        sb.Append(Environment.NewLine);
                        sb.Append(results);
                    }
                    continue;
                }
                catch (Exception ex)
                {
                    var results = ErrorMessage = $"Invalid Xpath: {value2[item].XPath} For Field:{item} Error:{ex.Message}";
                    /*return results*/
                    ;
                }
            }
            return "";
        }
