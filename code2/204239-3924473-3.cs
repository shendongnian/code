                private object _RowLocker = new object();
                /// <summary>
                /// Increment the number of rows that have been fully processed
                /// </summary>
                /// <param name="ar"></param>
                private void InvokationCompleted(IAsyncResult ar)
                {
                    lock (_RowLocker) { _RowsHandled++; }
         
                    if (_TotalThreads == _ThreadsHandled) _CompletedHandle.Set();
                }
