    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (SelectionForm selectionForm = new SelectionForm())
            {
                selectionForm.ShowDialog();
                txtSelection.Text = selectionForm.Selection;
            }
        }
    }
