        //Call the asynchronous operation
        Action callAndProcess = delegate { longOpDelegate(); Callafter(); };
        IAsyncResult result = callAndProcess.BeginInvoke(r => callAndProcess.EndInvoke(r), null);
        //Wait for it to complete
        result.AsyncWaitHandle.WaitOne();
        //return result saved in Callafter
        return longOpResult;
