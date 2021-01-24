     String result = string.Empty;
    
    var exist = xdoc.Descendants("Properties").Descendants("prop1").Attributes("Name").Where(x => x.Value.Equals(value)).FirstOrDefault();
    
      if (exist != null) 
      {
       XElement xElement = xdoc.Descendants("prop1").Where(x => x.Attribute("Name").Value.Equals(value).Select(x => x).FirstOrDefault();
           
       var childPropsExist = xElement.Elements("childprop").Any();
    
       if (childPropsExist) //we will be needing second input
       {
    
        result = xElement.Elements("childprop").Attributes("Name").Where(x => x.Value.Equals(secondInput)).FirstOrDefault().NextAttribute.Value;
    
       } else {
        result = exist.NextAttribute.Value; //Default value;
       }
      }
    
    return result;
