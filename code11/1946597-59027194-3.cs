    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            FlowPanel.FlowItemClicked += FlowPanel_FlowItemClicked;
        }
        private void FlowPanel_FlowItemClicked(object sender, EventArgs e)
        {
            MessageBox.Show("I'm called because A flow item in the flow panel was clicked."); 
        }
    }
