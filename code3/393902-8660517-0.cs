    var result = new System.Text.StringBuilder();
    var namedElements = doc.Descendants().Where(el => el.Attributes("name")!=null);
    foreach(var el in namedElements)
    {
      int depth = el.Ancestors().Count();
      for (int i=0;i<depth;i++)
        result.Append(" "); 
    
      result.Append(el.Attributes("name").Value);
      result.Append(System.Environment.NewLine);
    }
