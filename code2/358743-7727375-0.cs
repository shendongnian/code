    public class StrictNumericUpDown : NumericUpDown
    {
        protected override void OnTextBoxTextChanged(object source, EventArgs e)
        {
            base.OnTextBoxTextChanged(source, e);
            if (Value > Maximum)
            {
                Value = Maximum;
            }
        }
    }
