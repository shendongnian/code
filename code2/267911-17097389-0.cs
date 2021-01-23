    public partial class TextPrompt : Form
    {
        public string Value
        {
            get { return tbText.Text.Trim(); }
        }
        public TextPrompt(string promptInstructions)
        {
            InitializeComponent();
            lblPromptText.Text = promptInstructions;
        }
        private void BtnSubmitText_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TextPrompt_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
