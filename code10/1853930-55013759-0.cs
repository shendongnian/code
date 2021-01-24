    public class SpeechResponse
    {
        public Result[] results { get; set; }
    }
    public class Result
    {
        public Alternative[] alternatives { get; set; }
    }
    public class Alternative
    {
        public string transcript { get; set; }
        public float confidence { get; set; }
    }
