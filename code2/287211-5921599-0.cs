    public class NumericUpDownEx : NumericUpDown
    {
        public NumericUpDownEx()
        {
        }
 
        protected override void UpdateEditText()
        {
            // Append the units to the end of the numeric value
            this.Text = this.Value + " uA";
        }
    }
