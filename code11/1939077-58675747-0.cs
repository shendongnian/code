             public void Initialize()
             {
                CancellationTokenSource cts=new CancellationTokenSource();
                Task myTask=Task.Run(()=>Worker(cts.Token),cts.Token);
                TriggerLoop(cts);
             }
             public void TriggerLoop(CancellationTokenSource cts)
             {
                while(true)
                {
                   if(Console.ReadKey().Key=='A')
                   {
                    cts.Cancel();
                   }
                }       
             }
    
             public void Worker(CancellationToken token)
             {
               while(true)
                {
                  //do your stuff
                  if(token.IsCancellationRequested)
                  {
                      token.ThrowIfCancellationRequested();
                  }
               }
            }
