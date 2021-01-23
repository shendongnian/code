    ...
    xmlreader xmlToMerge1 = xmlreader.create(XmlSourceVariableHere);
    xmlreader xmlToMerge2 = xmlreader.create(XmlSourceVariableToMergeHere);
    xmlwriter xmlout = new xmlwriter(someStreamOrOther);
    
    xmlout.writeBeginElement("parentnode");
    xmlout.writeBeginElement("shapes");
    
    while (xmlToMerge1.Read())
     {
     if (xmlreader.nodetype == element && xml.Name == "shape")
      {
      xmlToMerge1.WriteNodeTo(xmlout);
      }
     }
    
    while (xmlToMerge2.Read())
     {
     if (xmlToMerge2.nodetype == element && xmlToMerge2.Name == "shape")
      {
      xmlToMerge2.WriteNodeTo(xmlout);
      }
     }
    
    
    xmlout.writeEndNode(); // end shapes
    xmlout.writeEndNode(); // end parentnode
