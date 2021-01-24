    List<Object> objects;
    //add items to list
    ...
    if(objects != null)
    {
      string text = "";
  
      foreach (Object obj in objects)
      {
        text += GetText(obj, 0);
      }
    
      File.WriteAllText(Server.MapPath("~/sample.txt"), text);
    }
