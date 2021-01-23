    public int requested_file_count = 5;
    public list<string> filenames;
    public FileServiceClient svc 
    //Constructor
    public Example()
    {
       svc = new FileServiceClient();
    } 
    Public void GetFiles()
    {
        //Initialise the list of names and set the count of files received     
        filenames = new list<string>(5);
        requested_file_count = filenames.Count; 
       svc.GetFileCompleted += new EventHandler<GetFileCompletedEventArgs>(GetFile_Completed);
       //Call the Async Method passing it the file name and setting the userstate to 1;
      
       svc.GetFileAsync(filenames[0],1);
    }
   
    void GetFile_Completed(object Sender, GetFileCompletedEventArgs e)
    {
       if (e.UserState == requested_file_count)
       {
         //All files have been downloaded
       }
       else
       {
          svc.GetFileAsync(filenames[e.UserState],++e.UserState);
       }
       //Do Something with the downloaded file
       byte[] filedata = e.result;
    }
