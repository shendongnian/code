    public class JobViewModel
    {
        public string Guid { get; set; }
        public bool Selected { get; set; }
    }
    public class MyViewModel
    {
        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
