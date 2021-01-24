    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var item in tableLayoutPanel1.Controls.OfType<LabelNumeric>())
            {
                var pos = tableLayoutPanel1.GetCellPosition(item);
                item.Caption = $"Row{pos.Row}Col{pos.Column}";
            }
        }
    }
