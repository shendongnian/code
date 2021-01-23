    // change parameter type to object and int he method just cast it to string
    public System.Drawing.Bitmap CaptureWebPage(object rawUrl) 
    {
       string url = rawUrl.ToString();
    }
    // start thread
    Thread thr = new Thread(CaptureWebPage); 
    thr.Start("url");
