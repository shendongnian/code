    public class AsyncFileWriter
        {
            private readonly FileStream fs;
            private readonly AsyncCallback callback;
            public Action FinishedCallback;
            private IAsyncResult result;
            private class AsyncState
            {
                public FileStream Fs;
            }
    
            private void WriteCore(IAsyncResult ar)
            {
                if (result != null)
                {
                    FileStream stream = ((AsyncState)ar.AsyncState).Fs;
                    stream.EndWrite(result);
                    if (this.FinishedCallback != null)
                    {
                        FinishedCallback();
                    }
                }
            }
    
            public AsyncFileWriter(FileStream fs, Action finishNotification)
            {
                this.fs = fs;
                callback = new AsyncCallback(WriteCore);
                this.FinishedCallback = finishNotification;
            }
    
            public AsyncFileWriter(FileStream fs)
                : this(fs, null)
            {
    
            }
            
    
            public void Write(Byte[] data)
            {
                result = fs.BeginWrite(data, 0, data.Length, callback, new AsyncState() { Fs = fs });
            }
        }
