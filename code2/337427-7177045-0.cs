    private void FSWatcherTest_Created(object sender, System.IO.FileSystemEventArgs e)
    {
        FileMover(object sender, System.IO.FileSystemEventArgs e);
    }
    
    private void FileMover(object sender, System.IO.FileSystemEventArgs e)
    {
        try{
        //Some code
        File.Move(oldfilepath, newfilepath);
        //some code
        }
        catch
        {
             //Call an asynchronous method that will wait 1 second then call FileMover again       
             //with the same arguments,
             //a BackGroundWorker would be perfect for that job.
        }
    }
