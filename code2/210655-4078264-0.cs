    static FSharpAsync<T> CreateAsync<T>(Func<Task<T>> f)
    { 
      return FSharpAsync.FromContinuations<T>(
        FuncConvert.ToFSharpFunc<
          Tuple< FSharpFunc<T, Unit>, 
                 FSharpFunc<Exception, Unit>,
                 FSharpFunc<OperationCanceledException, Unit> >>(conts => {
        f().ContinueWith(task => {
          try { conts.Item1.Invoke(task.Result); }
          catch (Exception e) { conts.Item2.Invoke(e); }
        });
      }));
    }
    static void MailboxProcessor() {
      var body = FuncConvert.ToFSharpFunc<
                    FSharpMailboxProcessor<int>, 
                    FSharpAsync<Unit>>(mbox =>
        CreateAsync<Unit>(async () => {
          while (true) {
            var msg = await FSharpAsync.StartAsTask
              ( mbox.Receive(FSharpOption<int>.None), 
                FSharpOption<TaskCreationOptions>.None, 
                FSharpOption<CancellationToken>.None );
            Console.WriteLine(msg);
          }
          return null;
        }));
      var agent = FSharpMailboxProcessor<int>.Start(body,
                    FSharpOption<CancellationToken>.None);
      agent.Post(1);
      agent.Post(2);
      agent.Post(3);
      Console.ReadLine();
    }
