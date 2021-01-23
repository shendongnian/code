    public class NumericUpDownExt : NumericUpDown
    {
        private static FieldInfo upDownEditField;
        private static PropertyInfo selectionStartProperty;
        private static PropertyInfo selectionLengthProperty;
        static NumericUpDownExt()
        {
            upDownEditField = (typeof(UpDownBase)).GetField("upDownEdit", BindingFlags.Instance | BindingFlags.NonPublic);
            Type upDownEditType = upDownEditField.FieldType;
            selectionStartProperty = upDownEditType.GetProperty("SelectionStart");
            selectionLengthProperty = upDownEditType.GetProperty("SelectionLength");
        }
        public NumericUpDownExt() : base()
        {
        }
        public int SelectionStart
        {
            get
            {
                return Convert.ToInt32(selectionStartProperty.GetValue(upDownEditField.GetValue(this), null));
            }
            set
            {
                if (value >= 0)
                {
                    selectionStartProperty.SetValue(upDownEditField.GetValue(this), value, null);
                }
            }
        }
        public int SelectionLength
        {
            get
            {
                return Convert.ToInt32(selectionLengthProperty.GetValue(upDownEditField.GetValue(this), null));
            }
            set
            {
                selectionLengthProperty.SetValue(upDownEditField.GetValue(this), value, null);
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            int pos = SelectionStart;
            string textBefore = this.Text;
            ParseEditText();
            string textAfter = this.Text;
            pos += textAfter.Length - textBefore.Length;
            SelectionStart = pos;
            base.OnTextChanged(e);
        }
    }
