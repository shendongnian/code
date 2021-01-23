    XmlReader reader; // Do whatever you want
    try
    {
      XDocument.Load(reader);
    }
    catch (ArgumentNullException)
    {
      // The input value is null.
    }
    catch (SecurityException)
    {
      // The XmlReader does not have sufficient permissions 
      // to access the location of the XML data.
    }
    catch (FileNotFoundException)
    {
      // The underlying file of the path cannot be found
    }
