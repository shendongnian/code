                   var sync = Bus.Send<SomeMessage>(/*data*/)
                    .Register((AsyncCallback)delegate(IAsyncResult ar)
                                  {
                                      var result = ar.AsyncState as CompletionResult;
                                      // do something with result.Messages
                                  },
                                  null
                    );
                   sync.AsyncWaitHandle.WaitOne( /*timeout*/);
