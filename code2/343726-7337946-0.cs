    public class DataVM
    {
        public string Input { get; set; }
    
        [Compare("Input")]
        public string ConfirmInput { get; set; }
    }
