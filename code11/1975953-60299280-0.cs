    public class SelectedButton
    {
        public int ID { get; set; }
        public bool Shown { get; set; }
        public string Class => Shown ? "red" : "";
    }
