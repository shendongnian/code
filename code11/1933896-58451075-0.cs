    Type[] _knownExpressions = new Type[]
    {
         typeof(SimpleExpression),
         typeof(CompositeExpression)
    };
    string expression = string.Empty;
    Expression exp = new Expression(){
       // Fill the object
    };
    MemoryStream ms = new MemoryStream();
    DataContractSerializer dcs = new DataContractSerializer(typeof(Expression), _knownExpressions);                                        
    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, System.Text.Encoding.Default))
    {
          xmlTextWriter.Formatting = Formatting.None;
          dcs.WriteObject(xmlTextWriter, exp);
          xmlTextWriter.Flush();
          xmlTextWriter.BaseStream.Position = 0;
          StreamReader sr = new StreamReader(xmlTextWriter.BaseStream);
          expression = sr.ReadToEnd();
          sr.Close();
     }
