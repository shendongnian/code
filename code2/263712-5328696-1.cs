    public static void createReport()
    {
      ReportingService rs = new ReportingService();
      rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
      Byte[] definition = null;
      Warning[] warnings = null;
      string name = "HereGoesNothing";
      try
      {
         FileStream stream = File.OpenRead(@"C:\HereGoesNothing.rdl");
         definition = new Byte[stream.Length];
         stream.Read(definition, 0, (int) stream.Length);
         stream.Close();
      }
      catch(IOException e)
      {
         Console.WriteLine(e.Message);
      }
      try
      {
         warnings = rs.CreateReport(name, "/", false, definition, null);
         if (warnings != null)
         {
            foreach (Warning warning in warnings)
            {
               Console.WriteLine(warning.Message);
            }
         }
         else
            Console.WriteLine("Report: {0} created successfully with no warnings", name);
      }
      catch (SoapException e)
      {
         Console.WriteLine(e.Detail.InnerXml.ToString());
      }
   }
