     XmlSerializer xsSubmit = new XmlSerializer(typeof(MyObject));
     var subReq = new MyObject();
     var xml = "";
     using(sww = new StringWriter())
     {
         using(XmlWriter writer = XmlWriter.Create(sww))
         {
             xsSubmit.Serialize(writer, subReq);
             xml = sww.ToString(); // Your XML
         }
     }
