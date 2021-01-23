    public class ViewModel
    {
        public ViewModel
        {
            DivId = string.Format("id_{0}", Guid.NewGuid());
        }
        public string DivId { get; private set; }
    }
