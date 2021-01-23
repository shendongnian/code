    public class SubForm : Form
    {
        public SubForm(MainForm parentForm)
        {
            _parentForm = parentForm;
        }
        
        private MainForm _parentForm;
        
        private void btn_UpdateClientName_Click(object sender, EventArgs e)
        {
            _parentForm.UpdateClientName(txt_ClientName.Text);
        }
    }
