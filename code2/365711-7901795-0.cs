    class Program
        {
            static void Main(string[] args)
            {
    
                WebClient wb = new WebClient();
                wb.DownloadDataAsync("www.hotmail.com");
                wb.DownloadDataCompleted += new DownloadDataCompletedEventHandler(wb_DownloadDataCompleted);
            }
    
            static void wb_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
            {
                if (e.Cancelled)//cancelled download by someone/may be you 
                {
                    //add necessary logic here
                }
                else if (e.Error)// all exception can be collected here including invalid download uri
                {
                    //add necessary logic here
                }
                else if (e.UserState)// get user state for asyn
                {
                    //add necessary logic here
                }
                else
                {
                    //you can assume here that you have result from the download.
                }
    
            }
        }
