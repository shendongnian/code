       //as global variable
       System.Windows.Forms.Timer delete_file = new System.Windows.Forms.Timer(); 
        
        Process.Start(file_path); //file_path is global variable
        
        delete_file.Tick += new EventHandler(timer_Tick); 
        delete_file.Interval = (2000);              
        delete_file.Enabled = true;                     
        delete_file.Start();
        
        private void timer_Tick(object sender, EventArgs e)
        {
           string file_name = Path.GetFileName(file_path);
           string file_extension = Path.GetExtension(file_name);
           Boolean file_is_opened = false;
           IEnumerable<Process> Searched_proces = null;
        
           //Check file extension to search only particular processes
           if (file_extension == ".xlsx")
           {
             Searched_proces = from xl in Process.GetProcessesByName("EXCEL") select xl;
           }
           else if (file_extension == ".pdf")
           {
             Searched_proces = from pdf in Process.GetProcessesByName("AcroRd32")
                                   select pdf;
           }
        
            //Loop proccesses and list active files in use
            foreach (var process in Searched_proces)
            {
              if (process.MainWindowTitle.Contains(Path.GetFileName(file_path)))
              {
                 file_is_opened = true;
              }
            }
        
             //If our file is not listed under active processes we check 
             //whether user has allready closed file - If so, we finally delete It
             if (file_is_opened==false)
             {
                if (!File_In_Use(new FileInfo(file_path)))
                {
                     File.Delete(file_path);
                     delete_file.Enabled = false;
                     delete_file.Stop();
                     return;
                 }
              }
         }
        
         private bool File_In_Use(FileInfo file)
         {
             //Method to check whether file is in use
        
             FileStream stream = null;
        
             try
             {
                  //If file doesn't exist
                  if (!file.Exists)
                  {
                         return false;
                  }
        
                  stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
             }
             catch (IOException)
             {
                   //File is unavailable:
                  //because someone writes to It, or It's being processed
                  return true;
             }
             finally
             {
                if (stream!=null)
                {
                  stream.Close();
                }
             }
        
                 //File not locked
                 return false;
          }
