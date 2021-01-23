    public class UpperCaseTextBox : TextBox
    {
        public UpperCaseTextBox()
            : base()
        {
            base.CharacterCasing = this.CharacterCasing;
        }
        private CharacterCasing _characterCasing = CharacterCasing.Upper;
        [DefaultValue(CharacterCasing.Upper)]
        public new CharacterCasing CharacterCasing
        {
            get
            {
                return _characterCasing;
            }
            set
            {
                base.CharacterCasing = value;
                _characterCasing = value;
            }
        }
    }
