    try
    {
      validateXMLHierarchy();
    }
    catch (XmlValidationException ex)
    {
      Console.Error.WriteLine(ex.Message);
    }
