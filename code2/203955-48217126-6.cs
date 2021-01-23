        public static void AsyncExecutionContext(DataRow currentRow, AsyncExecutionTask test) 
        {
            if(!BatchStarted)
            {
                foreach(DataRow row in currentRow.Table)
                {
                    Task testTask = new Task(()=> { test.Invoke(row); });
                    AsyncExecutionTests.Add(row[0].ToString(), testTask);
                    testTask.Start();
                }
                BatchStarted = true;
            }
            Task currentTestTask = AsyncExecutionTests[row[0].ToString()];
            currentTestTask.Wait();
            if(currentTestTask.Exception != null) throw currentTestTask.Exception;
        }
