    ...
    private void appendToProducts(string xmlFilePath, int productId, string productName, string productImage, string productPrice, string productDescription) {
        XmlDocument xmlDoc = new System.Xml.XmlDocument();        
        //LOAD FILE
        xmlDoc.load(xmlFilePath);
        XmlElement productElement = xmlDoc.CreateElement("product"); //CREATE <product> node
        //Create child nodes
        XmlElement idElement = xmlDoc.CreateElement("Id");
        XmlElement nameElement = xmlDoc.CreateElement("Product_Name");
        XmlElement priceElement = xmlDoc.CreateElement("Product_Price");
        XmlElement imgElement = xmlDoc.CreateElement("Product_image");
        XmlElement descElement= xmlDoc.CreateElement("Product_Description");
        idElement.InnerText = productId.ToString();
        nameElement.InnerText = productName;
        priceElement.InnerText = productPrice;
        imgElement.InnerText = productImage;
        descElement.InnerText = productDescription;
        //Append childs element to product node
        productElement.AppendChild(idElement);
        productElement.AppendChild(nameElement);
        productElement.AppendChild(priceElement);
        productElement.AppendChild(imgElement);
        productElement.AppendChild(descElement);
        //Append <product> to <productdetails> root element
        xmlDoc.DocumentElement.AppendChild(productElement);
        //Save
        xmlDoc.Save(xmlFilePath)
    }
    ...
