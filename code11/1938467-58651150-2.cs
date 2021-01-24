    public abstract class WorkbenchAPI
    {
		protected abstract IReadOnlyCollection<dynamic> GetResults();
		
        public string status { get; set; }
        public HttpStatusCode code { get; set; }
        public string error { get; set; }
        public string guid { get; set; }
		public IReadOnlyCollection<dynamic> results => GetResults();
    }
    public class WorkbenchAPI<T> : WorkbenchAPI where T : class
    {
		protected override IReadOnlyCollection<dynamic> GetResults() => results;
		public new List<T> results { get; set; } = new List<T>();
	}
