    SychronizingHandler : InterceptingHandler
    {
        // ...
        
        Semaphore mySemaphore;
        protected override bool PreFilter(System.Web.HttpContext context)
        {
            context.RewritePath("myFilePath");
            if( mySemaphore == null)
            {
                bool created;
                mySemaphore = new Semaphore(100, 0, "semphoreName", out created);
            }
            if( mySemaphore != null)
            {
                mySemaphore.WaitOne();
            }
            reutrn true;
        }
        // note this function isn't in the base class
        // you would need to add it  and call it right after the call to
        // innerHandler.ProcessRequest
        protected override void PostFilter(System.Web.HttpContext context) 
        {
            mySemaphore.Release();
            return;
        }
        protected virtual void OnError(HttpContext context, Exception except)
        {
            mySemaphore.Release();
            return base.OnError(context, except);
        }
