     string containerSasToken = container.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                    {
                        SharedAccessStartTime = DateTime.UtcNow,
                        SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddDays(1),
                        Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List
                    });
    
                    string containerSasUrl = String.Format("{0}{1}", container.Uri, containerSasToken);
                    var inputFiles = new List<ResourceFile> { };
                    var file = ResourceFile.FromStorageContainerUrl(containerSasUrl,"test");
                    inputFiles.Add(file);
                    Console.WriteLine(inputFiles.Count);
                    
                    // Get a Batch client using account creds
    
                    BatchSharedKeyCredentials cred = new BatchSharedKeyCredentials(BatchAccountUrl, BatchAccountName, BatchAccountKey);
    
                    using (BatchClient batchClient = BatchClient.Open(cred))
                    {
                        Console.WriteLine("getting pool [{0}]...", PoolId);
    
    
                        batchClient.PoolOperations.GetPool(PoolId);
                        
                        // Create a Batch job
                        Console.WriteLine("Creating job [{0}]...", JobId);
    
                        try
                        {
                            CloudJob job = batchClient.JobOperations.CreateJob();
                            job.Id = JobId;
                            job.PoolInformation = new PoolInformation { PoolId = PoolId };
    
                            job.Commit();
                        }
                        catch (BatchException be)
                        {
                            // Accept the specific error code JobExists as that is expected if the job already exists
                            if (be.RequestInformation?.BatchError?.Code == BatchErrorCodeStrings.JobExists)
                            {
                                Console.WriteLine("The job {0} already existed when we tried to create it", JobId);
                            }
                            else
                            {
                                throw; // Any other exception is unexpected
                            }
                        }
    
                        // Create a collection to hold the tasks that we'll be adding to the job
    
                        Console.WriteLine("Adding {0} tasks to job [{1}]...", inputFiles.Count, JobId);
    
                        List<CloudTask> tasks = new List<CloudTask>();
    
                        // Create each of the tasks to process one of the input files. 
    
                        for (int i = 0; i < inputFiles.Count; i++)
                        {
                            string taskId = String.Format("Task{0}", i);
                            string inputFilename = inputFiles[i].FilePath;
                            string taskCommandLine = String.Format("cmd /c type {0}", inputFilename);
    
                            CloudTask task = new CloudTask(taskId, taskCommandLine);
                            task.ResourceFiles = new List<ResourceFile> { inputFiles[i] };
                            tasks.Add(task);
                        }
    
                        // Add all tasks to the job.
                        batchClient.JobOperations.AddTask(JobId, tasks);
    
    
                        // Monitor task success/failure, specifying a maximum amount of time to wait for the tasks to complete.
    
                        TimeSpan timeout = TimeSpan.FromMinutes(30);
                        Console.WriteLine("Monitoring all tasks for 'Completed' state, timeout in {0}...", timeout);
    
                        IEnumerable<CloudTask> addedTasks = batchClient.JobOperations.ListTasks(JobId);
    
                        batchClient.Utilities.CreateTaskStateMonitor().WaitAll(addedTasks, TaskState.Completed, timeout);
    
                        Console.WriteLine("All tasks reached state Completed.");
    
                        // Print task output
                        Console.WriteLine();
                        Console.WriteLine("Printing task output...");
