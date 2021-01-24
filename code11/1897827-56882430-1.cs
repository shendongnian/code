    var serializer = new XmlSerializer(typeof(Configuration));
    using (System.IO.TextReader reader = new System.IO.StringReader(<Your XML String>))
    {
         Configuration config = (Configuration)serializer.Deserialize(reader);
    }
