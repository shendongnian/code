            var op = Dispatcher.BeginInvoke(new ThreadStart(DoSomething),
                                            DispatcherPriority.Send, 
                                            new object[] { args.EventObj });
            op.Completed += (s,e) => logger.Debug("Completed");
            op.Aborted += (s,e) => logger.Debug("Aborted");
