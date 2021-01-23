        var prod = new List<string>();
        prod.Add("Apples");
        prod.Add("Oranges");
        var doc = new XElement("Product");
        foreach(String p in prod){
            doc.Add(new XElement("products", p));
        }
        Debug.WriteLine(doc.ToString());
