    public partial class Prompt : Form {   
        
                public Prompt(string message) {
                    InitializeComponent();
                    this.labelforMessage.Text = message;   // Use this string as label text
                }
        
                private void btnOk_Click(object sender, EventArgs e) {
                    this.Hide();
                }
            }
