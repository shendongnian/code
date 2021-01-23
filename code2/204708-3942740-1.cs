    public class UpperCaseDataGridView : DataGridView
    {
        private CharacterCasing _textBoxCharacterCasing = CharacterCasing.Upper;
        [CategoryAttribute("Behavior")]
        [DescriptionAttribute("Sets CharacterCasing of all contained TextBox controls.")]
        [DefaultValue(CharacterCasing.Upper)]
        public CharacterCasing TextBoxCharacterCasing
        {
            get
            {
                return _textBoxCharacterCasing;
            }
            set
            {
                _textBoxCharacterCasing = value;
            }
        }
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            var txtBox = EditingControl as TextBox;
            if (txtBox != null)
                txtBox.CharacterCasing = this.TextBoxCharacterCasing;
            base.OnEditingControlShowing(e);
        }
    }
