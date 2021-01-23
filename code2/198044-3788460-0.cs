    using(var sr = new StringReader(stringBuilder.ToString)) {
      using(var xr = XmlReader.Create(sr)) {
        while(xr.Read()) {
          if(xr.IsStartElement() && xr.LocalName == "node")
            xr.ReadElementString(); //Do something here
        }
      }
    }
