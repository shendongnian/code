    System.Drawing.Bitmap bitmapObject;
    private static readonly bitmapLock = new object();
    // change parameter type to object and int he method just cast it to string
    public void CaptureWebPage(object rawUrl) 
    {
       string url = rawUrl.ToString();
       lock(bitmapLock)
       {
          // create a bitmap object
          bitmapObject = ...;
       }
    }
    // start thread
    Thread thr = new Thread(CaptureWebPage); 
    thr.Start("url");
