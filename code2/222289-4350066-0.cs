            var dispatcher = new MessageDispatchDelegate(DispatchMessage);
            
            var asyncResult = dispatcher.BeginInvoke(requestMessage, DispatchMessageCallback, null);
            if (!asyncResult.AsyncWaitHandle.WaitOne(1000, false))
            {
                 /*Timeout action*/
            }
            else
            {
                response = dispatcher.EndInvoke(asyncResult);
            }
