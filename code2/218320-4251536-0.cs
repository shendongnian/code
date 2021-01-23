    public class A : BaseClass
    {
        public event EventHandler OnChanged;
    
        [ChangedNotify("OnChanged")]
        public bool HasChanged { get; set; }
    }
