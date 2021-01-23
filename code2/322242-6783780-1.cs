    object key = new object();
    private void btnClick_DragDrop(object sender, DragEventArgs e)
    {
        // your code ...
    
        //Start  thread
        try
        {
            Console.WriteLine("++ Calling testthread with these params: false, " + ButtonName + "," + CleanFileName + "," +     file);
            lock (key)
            {
                string[] fileCopy;
                file.CopyTo(fileCopy);
                new Thread(() => testthread(false, ButtonName, CleanFileName, fileCopy)).Start();
            }
            Console.WriteLine("++ testthead thread started @ " + DateTime.Now);
        }
        catch (Exception ipwse)
        {
            logger.Debug(ipwse.Message + " " + ipwse.StackTrace);
        }
    }
