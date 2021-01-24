    var xpath = "//a[.='Sana']/following-sibling::b[1]/span";
    string price = htmlDoc.DocumentNode
    					  .SelectSingleNode(xpath)
    					  .InnerText;
    Console.WriteLine(price.Text);
