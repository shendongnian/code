     bool _requestPending;
     readonly object _lock = new object();
     void OnClick (...)
     {
         lock(_lock)
         {
            if (_requestPending == false)
            {
                _dataService.GetData(GetDataCompleted);
                _requestPending = true;
            }
         }
     }
     private void GetDataComplete(Data data)
     {
         lock(_lock)
         {
            try
            {
               //do something with data 
            }
            finally
            {
               _requestPending = false;
            }  
         }           
     }
