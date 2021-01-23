    var context = new CaptureWebPageContext() { Url = url, ResultDelegate = BitmapRendered };
    var thr = new Thread(context);
    thr.Start(context);
    protected void BitmapRendered(Bitmap result)
    {
        // ... Do stuff with the final bitmap.
    }    
    protected void CaptureWebPage(object contextObject)
    {
        var context = (CaptureWebPageContext)contextObject;
        var url = context.Url;
        
        //... Your code to capture the web page.
        
        context.ResultDelegate(bmp);
        bmp.Dispose();
    }
