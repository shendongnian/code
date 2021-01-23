     try
     {
         var myResult = await Foo();
   
         // Do Success Actions Here... 
     }
     catch(AggregateException e)
     {
         e.Flatten().Handle(ex =>
           {
               if(ex is OperationCanceledException)
               {
                   // Do Canceled Thing Here
               }
               throw ex; // Otherwise throw
           });
     }
