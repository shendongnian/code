     void SendTileTextNotification(string text, int secondsExpire)
            {
                // Get a filled in version of the template by using getTemplateContent
                var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText03);
    
                // You will need to look at the template documentation to know how many text fields a particular template has       
    
                // get the text attributes for this template and fill them in
                var tileAttributes = tileXml.GetElementsByTagName(&quot;text&quot;);
                tileAttributes[0].AppendChild(tileXml.CreateTextNode(text));
    
                // create the notification from the XML
                var tileNotification = new TileNotification(tileXml);
    
                // send the notification to the app's default tile
                TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
            }
