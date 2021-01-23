    void ProcessorMethod()
    {
         while (_shouldEnd)
         {
             CustomEventArgs e=null;
             lock (_argsqueue)
             {
                 if (_argsqueue.Count>0)
                 {
                     CustomEventArgs e=_argsqueue[0];
                     _argsqueue.RemoveAt(0);
                 }
             }
             if (e!=null) 
             {
                 DoLongOperation(e);
             }
             else
             {
                 Sleep(100);
             }
         }
    }
