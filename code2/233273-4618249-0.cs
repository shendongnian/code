    Bus.Send<IRequestDataMessage>(m =>
                {
                    m.DataId = g;
                    m.String = "<node>it's my \"node\" & i like it<node>";
                })
                    .Register(i => Console.Out.WriteLine(
                                       "Response with header 'Test' = {0}, 1 = {1}, 2 = {2}.",
                                       Bus.CurrentMessageContext.Headers["Test"],
                                       Bus.CurrentMessageContext.Headers["1"],
                                       Bus.CurrentMessageContext.Headers["2"]));
