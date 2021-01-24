    var UrlExterne = "https://www.google.fr";
    var filetemp = $"{Path.GetTempFileName()}.url";
    try
    {
         using (var sw = new StreamWriter(filetemp))
         {
              sw.WriteLine("[InternetShortcut]");
              sw.WriteLine($"URL={UrlExterne}");
              sw.Close();
          }
          System.Diagnostics.Process.Start(filetemp);
     }
     finally
     {
         if(File.Exists(filetemp))
              File.Delete(filetemp);
     }
