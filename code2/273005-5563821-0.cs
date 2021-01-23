    public enum PrintJobStatus
    // Check for possible trouble states of a print job using the flags of the JobStatus property
    internal static void SpotTroubleUsingJobAttributes(PrintSystemJobInfo theJob)
    {
    if ((theJob.JobStatus & PrintJobStatus.Blocked) == PrintJobStatus.Blocked)
    {
    Console.WriteLine("The job is blocked.");
    }
    if (((theJob.JobStatus & PrintJobStatus.Completed) == PrintJobStatus.Completed)
    ||
    ((theJob.JobStatus & PrintJobStatus.Printed) == PrintJobStatus.Printed))
    {
    Console.WriteLine("The job has finished. Have user recheck all output bins and be sure the correct printer is being checked.");
    }
    if (((theJob.JobStatus & PrintJobStatus.Deleted) == PrintJobStatus.Deleted)
    ||
    ((theJob.JobStatus & PrintJobStatus.Deleting) == PrintJobStatus.Deleting))
    {
    Console.WriteLine("The user or someone with administration rights to the queue has deleted the job. It must be resubmitted.");
    }
    if ((theJob.JobStatus & PrintJobStatus.Error) == PrintJobStatus.Error)
    {
    Console.WriteLine("The job has errored.");
    }
    if ((theJob.JobStatus & PrintJobStatus.Offline) == PrintJobStatus.Offline)
    {
    Console.WriteLine("The printer is offline. Have user put it online with printer front panel.");
    }
    if ((theJob.JobStatus & PrintJobStatus.PaperOut) == PrintJobStatus.PaperOut)
    {
    Console.WriteLine("The printer is out of paper of the size required by the job. Have user add paper.");
    }
    
    if (((theJob.JobStatus & PrintJobStatus.Paused) == PrintJobStatus.Paused)
    ||
    ((theJob.HostingPrintQueue.QueueStatus & PrintQueueStatus.Paused) == PrintQueueStatus.Paused))
    {
    HandlePausedJob(theJob);
    //HandlePausedJob is defined in the complete example.
    }
    
    if ((theJob.JobStatus & PrintJobStatus.Printing) == PrintJobStatus.Printing)
    {
    Console.WriteLine("The job is printing now.");
    }
    if ((theJob.JobStatus & PrintJobStatus.Spooling) == PrintJobStatus.Spooling)
    {
    Console.WriteLine("The job is spooling now.");
    }
    if ((theJob.JobStatus & PrintJobStatus.UserIntervention) == PrintJobStatus.UserIntervention)
    {
    Console.WriteLine("The printer needs human intervention.");
    }
    
    }//end SpotTroubleUsingJobAttributes 
