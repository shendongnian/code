    class Caption
    {
        public string AR { get; set; }
        public string EN { get; set; }
        public string Tu { get; set; }
        // Gets the caption of the current language
        public string Current { get; private set; }
        // If the language is known in advance, you can return
        // the desired language directly.
        public static implicit operator string(Caption caption) 
            => caption.Current;
        public Caption For(string language)
        {
            var which = AR;
            switch (language)
            {
                case nameof(EN):
                    which = EN;
                    break;
                case nameof(Tu):
                    which = Tu;
                    break;
            }
            Current = which;
            return this;
        }
    }
    // Usage
    var cap = new Caption
    { 
        AR = "Test-ar",
        EN = "Test-en",
        Tu = "Test-tu"        
    }.For("EN");
    string s = cap;
    Console.WriteLine(s); // Test-en
