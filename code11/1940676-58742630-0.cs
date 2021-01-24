    XmlSerializer xsGList = new XmlSerializer(typeof(List<T>),
                                   new XmlRootAttribute("Ts"));
     var subReq = new List<T>(); // assign the value
     subReq=pp; 
     var xml = "";
    
     using(var stream = new StringWriter())
     {
      using(XmlWriter writer = XmlWriter.Create(stream))
      {
         xsGList.Serialize(writer, subReq);
         xml = stream.ToString(); // Your XML as string
      }
     }
