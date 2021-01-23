    public void ExtractValue(pdfClass incomingpdfClass, string type)
    {
      PropertyInfo pinfo = typeof(pdfClass).GetProperty("Top" + type);
      var yourList = pinfo.GetValue(incomingpdfClass);
      foreach (var listitem in yourList)
      { ... }
    }
