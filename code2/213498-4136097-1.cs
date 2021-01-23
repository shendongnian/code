    //Products declaration
    [XmlRoot(ElementName = "MyProducts")]
    public class MyProducts : List<Product>
    {
    }
    public class Product
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
    ...
    
    [Test]
    public void DeserializeFromString()
    {
        var xml = @"<?xml version='1.0' encoding='UTF-8;'?>  
          <MyProducts>  
            <Product Name='P1' />  
            <Product Name='P2' />  
          </MyProducts>";
        IList<Product> obj = Serialization<MyProducts>.DeserializeFromString(xml);
        Assert.IsNotNull(obj);
        Assert.AreEqual(2, obj.Count);
    }
    ...
    //Deserialization library
    public static T DeserializeFromString(string serialized)
    {
        var byteArray = Encoding.ASCII.GetBytes(serialized);
        var memStream = new MemoryStream(byteArray);
        return Deserialize(memStream);
    }
    public static T Deserialize(Stream stream)
    {
        var xs = new XmlSerializer(typeof(T));
        return (T) xs.Deserialize(stream);
    }
