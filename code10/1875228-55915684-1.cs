     public Task WaitUntilMessageIsNull(model DDSModel)
     {
         var tcs = new TaskCompletionSource<int>();
         PropertyChangedEventHandler handler = (o, e) => {
             if(model.Message == null && e.PropertyName == "Message")
             {
                tcs.SetResult(0);
                model.PropertyChanged -= handler;
             }
         }
         model.PropertyChanged += handler;
         return tcs.Task;
     }
