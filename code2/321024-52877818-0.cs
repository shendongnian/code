            var tasks = new Task[] { DoSomethingAsync(), DoSomethingElseAsync() };
            
            try
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch (AggregateException ex)
            {
                var flatAgrExs = ex.Flatten().InnerExceptions;
                foreach(var agrEx in flatAgrExs)
                {
                     //handle out errors
                     logger.LogError(agrEx, "Critical Error occurred");
                }
            }
`
