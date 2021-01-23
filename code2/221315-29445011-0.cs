    public  string GetCountryByIP(string ipAddress)
        {
            string strReturnVal;
            string ipResponse = IPRequestHelper("http://ip-api.com/xml/" + ipAddress);
    
            //return ipResponse;
            XmlDocument ipInfoXML = new XmlDocument();
            ipInfoXML.LoadXml(ipResponse);
            XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");
    
            NameValueCollection dataXML = new NameValueCollection();
                   
            dataXML.Add(responseXML.Item(0).ChildNodes[2].InnerText, responseXML.Item(0).ChildNodes[2].Value);
    
            strReturnVal = responseXML.Item(0).ChildNodes[1].InnerText.ToString(); // Contry
            strReturnVal += "(" + 
    responseXML.Item(0).ChildNodes[2].InnerText.ToString() + ")";  // Contry Code 
     return strReturnVal;
    }
