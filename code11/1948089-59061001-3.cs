    XElement target = XElement.Parse(txml);
    XElement source = XElement.Parse(sxml);
    var targetMergeAttrs = GetMergeAttr(target);
    var sourceMergeAttrs = GetMergeAttr(source);
    
    foreach (var sourceElement in source.Elements())
    {
       		foreach(var mergeField in sourceMergeAttrs)
    		{
    		
    			if(sourceElement.Attributes().Any(x=>x.Name.LocalName.Equals(mergeField)) &&
    			target.Elements()
    				  .Any(x=>x.Attributes()
    				  					  .Where(c=>c.Name.LocalName == mergeField 
    									  && targetMergeAttrs.Contains(mergeField)
    									  && c.Value == (string)sourceElement.Attribute(mergeField)).Any()
    									  ))
    			{
    		    	XElement targetElement = target.Elements()
    				  .FirstOrDefault(x=>x.Attributes()
    				  					  .Where(c=>c.Name.LocalName == mergeField 
    									  && targetMergeAttrs.Contains(mergeField)
    									  && c.Value == (string)sourceElement.Attribute(mergeField)).Any()
    									  );
    				targetElement.Dump();
    				break;
    			}
    		
        	}
    }
  
