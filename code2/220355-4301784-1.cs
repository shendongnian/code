    HtmlDocument doc = webBrowser1.Document;
    HtmlElementCollection optionValues = doc.GetElementsByTagName("OPTION");
    foreach (HtmlElement optTag in optionValues)
    {
        comboBox1.Items.Add(optTag.InnerText);
    }
