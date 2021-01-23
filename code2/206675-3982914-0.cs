    public sealed class EmailWorker
    {
        private EmailWorker() { }
        private static class NestedWorker
        {
            static NestedWorker() { }
            internal static readonly EmailWorker Instance = new EmailWorker();
        }
        public static EmailWorker Instance
        {
            get { return NestedWorker.Instance; }
        }
    }
