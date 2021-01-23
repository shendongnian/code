     XmlSerializer xsSubmit = new XmlSerializer(typeof(MyObject));
     var subReq = new MyObject();
     StringWriter sww = new StringWriter();
     using(XmlWriter writer = XmlWriter.Create(sww))
     {
         xsSubmit.Serialize(writer, subReq);
         var xml = sww.ToString(); // Your XML
     }
