     private void mnuContents_Click(object sender, EventArgs e)
     {
         if (Process.GetProcessById(self.previousId) != null) {
             string ApplicationPath=ConfigurationSettings.AppSettings["HelpFile"].ToString();
             info = new ProcessStartInfo(ApplicationPath);
             //Process.Start(info);
             exeprocess = Process.Start(info);
             self.previousId = exeprocess.Id;
         }
     }
