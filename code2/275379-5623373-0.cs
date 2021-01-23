    var processImagesDelegate = new ProcessImagesDelegate(ProcessImages2);  
    IAsyncResult result = processImagesDelegate.BeginInvoke(files, null, null);
    result.AsyncWaitHandle.WaitOne();
    **//HERE IS THE LINE OF CODE THAT NEED TO BE RUN AFTER EVERYTHING FINISH RUN   
    System.IO.File.Delete(@"C:\Users\Shen\Desktop\LenzOCR\TempFolder\tempPic.jpg");  
         
         
