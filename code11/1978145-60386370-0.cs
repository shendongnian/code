    [Designer(typeof(MyControlDesigner))]
    public partial class LabelNumeric : UserControl
    {
        public LabelNumeric()
        {
            InitializeComponent();
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, 24, specified);
        }
        [DefaultValue("Label")]
        public string Caption
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        [DefaultValue(0)]
        public decimal Value
        {
            get => numericUpDown1.Value;
            set => numericUpDown1.Value =value;
        }
        [DefaultValue(0)]
        public int DecimalPlaces
        {
            get => numericUpDown1.DecimalPlaces;
            set => numericUpDown1.DecimalPlaces = value;
        }
        [DefaultValue(100)]
        public decimal MaxValue
        {
            get => numericUpDown1.Maximum;
        }
        [DefaultValue(0)]
        public decimal MinValue
        {
            get => numericUpDown1.Minimum;
        }
    }
    internal class MyControlDesigner : ControlDesigner
    {
        MyControlDesigner()
        {
            base.AutoResizeHandles = true;
        }
        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;
            }
        }
    }
