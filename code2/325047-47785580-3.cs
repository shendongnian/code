    [HttpPost]
            public JsonResult SearchAction(string query, int instanceID)
            {           
                lock (tasks)
                {
                    tasks[instanceID] = new CancellationTokenSource();
                }
                CancellationToken ct = tasks[instanceID].Token;
                var searchTask = Task.Factory.StartNew(() => _SearchAction(query, instanceID, ct));
                JsonResult res;
                try
                {
                    res = searchTask.Result;
                }
                catch (OperationCanceledException)
                {
                    res = null;
                }
                lock (tasks)
                {
                    CancellationTokenSource temp;
                    tasks.Remove(instanceID, out temp);
                    temp.Dispose();
                }
                return res;
            }
