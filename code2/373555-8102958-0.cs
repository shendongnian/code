     private void mnuContents_Click(object sender, EventArgs e)
     {
         string ApplicationPath=ConfigurationSettings.AppSettings["HelpFile"].ToString();
         info = new ProcessStartInfo(ApplicationPath);
         //Process.Start(info);
         exeprocess = Process.Start(info);
     }
