    private async Task SyncStopOnException(IEnumerable<Func<Task>> handlers)
        {
            foreach (var handler in handlers)
            {
                object target = handler.Target;
                if (target != null)
                {
                    var xField = target.GetType().GetFields().Single(f => f.Name == "x");
                    var xFieldValue = xField.GetValue(target);
                    if (xFieldValue as IWithinTransaction != null)
                    {
                        
                    }
                }
                await handler().ConfigureAwait(false);                                
            }
        }
