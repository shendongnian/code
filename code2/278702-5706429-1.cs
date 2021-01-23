    public partial class NotifyForm : Form
        {
            public NotifyForm(string message, string title)
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;// Or wherever 
    
                lblMessage.Text = "\r\n" + message;
                this.Text =  title;
            }
    
            private void btnOK_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
