    [DescriptionAttribute("Expand to see the spelling options for the application.")]
    public class SpellingOptions
    {
        private bool spellCheckWhileTyping = true;
        private bool spellCheckCAPS = false;
        private bool suggestCorrections = true;
        [DefaultValueAttribute(true)]
        public bool SpellCheckWhileTyping 
        {
            get { return spellCheckWhileTyping; }
            set { spellCheckWhileTyping = value; }
        }
        [DefaultValueAttribute(false)]
        public bool SpellCheckCAPS 
        {
            get { return spellCheckCAPS; }
            set { spellCheckCAPS = value; }
        }
        [DefaultValueAttribute(true)]
        public bool SuggestCorrections 
        {
            get { return suggestCorrections; }
            set { suggestCorrections = value; }
        }
    }
