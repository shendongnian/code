    namespace MyControls
    {
        public partial class NumericUpDown : System.Windows.Forms.NumericUpDown
        {
            public Decimal MouseWheelIncrement { get; set; }
            
            public NumericUpDown()
            {
                MouseWheelIncrement = 1;
                InitializeComponent();
            }
    
            protected override void OnMouseWheel(MouseEventArgs e)
            {
                decimal newValue = Value;
                if (e.Delta > 0)
                    newValue += MouseWheelIncrement;
                else
                    newValue -= MouseWheelIncrement;
                if (newValue > Maximum)
                    newValue = Maximum;
                else
                    if (newValue < Minimum)
                        newValue = Minimum;
                Value = newValue;
            }
        }
    }
