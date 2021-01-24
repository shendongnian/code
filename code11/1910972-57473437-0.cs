    if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent responseContent = response.Content;
    
                    var json = await responseContent.ReadAsStringAsync();
    
                    XmlDocument doc = new XmlDocument();
    
                    doc.LoadXml(json);
    
                    var text = doc.GetElementsByTagName("text")[0].InnerText;
                }
