    public partial class DoubleAttributeTextBoxBase
        : NumericAttributeTextBoxBaseOfDouble
    {
        public DoubleAttributeTextBoxBase()
        {
            InitializeComponent();
        }
        // Now DoubleAttributeTextBoxBase is designable.
    }
    public class NumericAttributeTextBoxBaseOfDouble
        : NumericAttributeTextBoxBase<double>
    {
    }
