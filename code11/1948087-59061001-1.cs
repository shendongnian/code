    XElement target = XElement.Parse(txml);
    XElement source = XElement.Parse(sxml);
    var targetMergeAttrs = GetMergeAttr(target);
    var sourceMergeAttrs = GetMergeAttr(source);
    var mergeTargets = targetMergeAttrs.Zip(sourceMergeAttrs,(t,s)=>new {Target=t,Source=s});
    foreach(var mergeField in mergeTargets)
    {
       var targetMergeAttr = mergeField.Target;
       var sourceMergeAttr = mergeField.Source;
       foreach (var sourceElement in source.Elements())
       {
    	  XElement targetElement = target.Elements().SingleOrDefault(
    	                    t => 
    	                        String.Equals(
    	                            (string)t.Attribute(targetMergeAttr),
    	                            (string)sourceElement.Attribute(sourceMergeAttr),
    	                            StringComparison.InvariantCultureIgnoreCase)
    	                  );
    					  
    	}
    }
