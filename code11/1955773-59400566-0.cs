        foreach (HtmlNode link doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            string hrefValue = link.GetAttributeValue( "href", string.Empty );            
            MessageBox.Show(hrefValue);
            MessageBox.Show(link.InnerText);
        }
                   
