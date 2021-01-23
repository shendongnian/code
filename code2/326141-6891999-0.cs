    var p=new Person();
    p.FirstName = "Jeff";
    p.MI = "A";
    p.LastName = "Price";
    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
    x.Serialize(Console.Out, p);
