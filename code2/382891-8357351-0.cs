    public class BoolSetting
    {
        public string DisplayName { get; set; }
        public bool Value { get; set; }
    }
    public class MyViewModel
    {
        public List<BoolSetting> Settings { get; set; }
    }
