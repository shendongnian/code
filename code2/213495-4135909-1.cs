    string xml = @"<?xml version='1.0' encoding='UTF-8;'?> 
      <MyProducts> 
          <Product Name='P1' /> 
          <Product Name='P2' /> 
      </MyProducts>";
    //secret sauce:
    xml = xml.Replace("MyProducts>", "ArrayOfProduct>");
    IList myProducts;
    using (StringReader sr = new StringReader(xml))
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<Product>));
        myProducts = xs.Deserialize(sr) as IList;
    }
    foreach (Product myProduct in myProducts)
    {
        Console.Write(myProduct.Name);
    }
