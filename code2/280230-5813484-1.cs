    while (reader.Read()){
       if(reader.NodeType == XmlNodeType.Element && reader.Name == "name"){                               
           this.tagXml.Append("<").Append(reader.Name).Append(">");
           currentTag = reader.Name.Trim();
           //first loop go through this
       }                   
       if(reader.NodeType== XmlNodeType.Text){
          //second loop go through this
          if (currentTag == "name"){
            this.tagXml.Append(reader.Value);
          }
       }
    }
