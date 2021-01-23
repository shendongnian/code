    public class TestModelType
    {
        [BindAlias("LPN")]
        //and you can add multiple aliases
        [BindAlias("L")]
        //.. ad infinitum
        public string LongPropertyName { get; set; }
    }
