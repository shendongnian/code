C#
    public struct TranslationEntry
    {
        public string LangCode { get; set; }
        public string LangName { get; set; }
        public string Translation { get; set; }
    }
It should have been:
C#
    public class TranslationEntry
    {
        public string LangCode { get; set; }
        public string LangName { get; set; }
        public string Translation { get; set; }
    }
@Keithernet, thanks for your help.
