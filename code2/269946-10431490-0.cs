            try
            {
                var msg = mq.EndReceive(e.AsyncResult);
                if ( _shouldStop)
                {
                    idleWH.Set();
                    return;
                }
                mq.BeginReceive();
            }
 . . .
