    // serialize
    var ser= new NetDataContractSerializer();
    using(var fs= new StreamWriter(@"C:\testdata.xml"))
        ser.Serialize(fs, TestObj);
    // deserialize
    using(var fs= new FileStream(@"C:\testdata.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
    using (var xmlReader = new XmlTextReader(fs))
        Test test = (Test)ser.ReadObject(xmlReader);
