    // ...
    using FAXCOMEXLib;
    
    public class FaxServerListener
    {
        private FaxServer faxServer;
        public FaxServerListener(string faxServerMachineName)
        {
            faxServer = new FaxServer();
            faxServer.Connect(faxServerMachineName);
            RegisterFaxServerEvents();
        }
        private void RegisterFaxServerEvents()
        {
            // subscribe to multiple FaxServer events here ...
            faxServer.OnOutgoingJobChanged += faxServer_OnOutgoingJobChanged;
            /* very important, you MUST tell the FaxServer object which events you're
             * listening for, otherwise the events will never raise!
             * This is what I have set and you should only need one of the event types
             * to listen for but I didn't research this for your problem
             */
            var events = FAX_SERVER_EVENTS_TYPE_ENUM.fsetACTIVITY |
                         FAX_SERVER_EVENTS_TYPE_ENUM.fsetDEVICE_STATUS |
                         FAX_SERVER_EVENTS_TYPE_ENUM.fsetOUT_ARCHIVE |
                         FAX_SERVER_EVENTS_TYPE_ENUM.fsetOUT_QUEUE;
            faxServer.ListenToServerEvents(events);
        }
        private void faxServer_OnOutgoingJobChanged(FaxServer faxServer, string jobId,
            FaxJobStatus jobStatus)
        {
            // Of course you can do whatever you wish here. This is the method that
            // subscribes to the event with a JobStatus object
            string output = string.Format("Outgoing Job Changed -> {0}{1}{2}",
                jobId, Environment.NewLine, GetJobStatusOutput(jobStatus));
            // you could process the FaxJobStatus object how ever you wish here
            // I raised another event from this listener class with the output data
            // for other client code to listen to.
        }
        
        private string GetJobStatusOutput(FaxJobStatus jobStatus)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("\tDeviceID: " + jobStatus.DeviceId.ToString());
            sb.AppendLine("\tCurrent Page: " + jobStatus.CurrentPage.ToString());
            sb.AppendLine("\tExt. Status Code: " + jobStatus.ExtendedStatusCode.ToString());
            sb.AppendLine("\tExt. Status: " + jobStatus.ExtendedStatus);
            sb.AppendLine("\tJob Type: " + jobStatus.JobType.ToString());
            sb.AppendLine("\tRetries: " + jobStatus.Retries.ToString());
            sb.AppendLine("\tSize: " + jobStatus.Size.ToString());
            sb.AppendLine("\tStatus: " + jobStatus.Status.ToString());
            sb.AppendLine("\tStart: " + jobStatus.TransmissionStart.ToShortTimeString());
            if (jobStatus.ExtendedStatusCode != FAX_JOB_EXTENDED_STATUS_ENUM.fjesTRANSMITTING)
            {
                sb.AppendLine("\tStop: " + jobStatus.TransmissionEnd.ToShortTimeString());
            }
            sb.AppendLine("\tTSID: " + jobStatus.TSID);
            
            return sb.ToString();
        }
    }
