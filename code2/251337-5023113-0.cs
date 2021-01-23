    public partial class MyBox : Form
    {
        public MyBox()
        {
            InitializeComponent();
        }
    
        public string ResultText { get; set; }
    
        public static string GetString(string title)
        {
            var box = new MyBox {Text = title};
    
            if (box.ShowDialog() == DialogResult.OK)
            {
                return box.ResultText;
            }
    
            return string.Empty;
        }
    
        private void okButton_Click(object sender, EventArgs e)
        {
            this.ResultText = txtUserInput.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
