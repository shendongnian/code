        public partial class Form1 : Form
    {
        internal static Form1 ActiveForm { get; set; }
        public Form1()
        {
            InitializeComponent();
            ActiveForm = this;
        }
        public struct OrderLineItem
        {
            public override string ToString()
            {
                return ActiveForm.sizeComboBox.Items[index].ToString();
            }
        }
