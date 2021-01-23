        //Call the asynchronous operation
        Action callAndProcess = delegate { longOpDelegate(); Callafter(); };
        IAsyncResult result = callAndProcess.BeginInvoke(r => callAndProcess.EndInvoke(r), null);
        //return result saved in Callafter
        return longOpResult;
