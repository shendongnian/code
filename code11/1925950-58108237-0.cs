    public class Config
    {
        public UI Ui { get; set; }
        public Output Output { get; set; }
        public override string ToString()
        {
            return $"Config has properties:\n - Ui: {Ui}\n - Output: {Output}";
        }
    }
    public class UI
    {
        public string Colour { get; set; }
        public string Size { get; set; }
        public override string ToString()
        {
            return $"(Colour: {Colour}, Size: {Size})";
        }
    }
    public class Output
    {
        public string Mode { get; set; }
        public int Version { get; set; }
        public override string ToString()
        {
            return $"(Mode: {Mode}, Version: {Version})";
        }
    }
