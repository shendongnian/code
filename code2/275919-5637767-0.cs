      using (FileStream READER = new FileStream(fpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
      {
           System.Xml.XmlDocument Template = new System.Xml.XmlDocument();// Set up the XmlDocument //
           Template.Load(READER); //Load the data from the file into the XmlDocument //
      }
      //**********Grab nodes to be written to********
      using (FileStream WRITER = new FileStream(fpath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
      {
         //Set up the filestream (READER) //
         //Write the data to the filestream
         Template.Save(WRITER);
         ...
      }
