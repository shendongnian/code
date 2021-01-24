    StringBuilder bodyContent = new StringBuilder();    
    string fileName = "myfile.txt";
    try
    {
      string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
      using (StreamReader sr = new StreamReader(filePath))
      {
        // Read the stream.
        bodyContent.Append(sr.ReadToEnd());
      }
    }
    catch(Exception ex)
    {
       Console.WriteLine(String.Format("{0} @ {1}", "Exception while reading the file: " + ex.InnerException.Message, DateTime.Now));
       throw ex;
    }
    
    
    
