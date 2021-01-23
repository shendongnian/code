    public class DownloadFileJob : IJob
    {
        public IBus Bus { get; set; }
        public ILogger Logger{ get; set; }
        public void Execute(IJobExecutionContext context)
        {
            Bus.Send(new DownloadFileMessage());
            Logger.Info("Sending message requesting download of file.");
        }
    }
