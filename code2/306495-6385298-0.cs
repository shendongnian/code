        lock ( MsgQueue ) {
            if ( MsgQueue.Count == 0 ) {  // LINE 1
                Monitor.Wait( MsgQueue ); // LINE 2
                continue;
            }
            msg = MsgQueue.Dequeue( ); // LINE 3
        }
