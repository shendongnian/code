    public partial class Form1 : Form
        {      
            string svar;  // <----------- place here.  Now it is a 'field'
            public Form1()
            {
                InitializeComponent();
            }
    
            private void TbxSvar_TextChanged(object sender, EventArgs e)
            {
                if (tbxSvar.TextLength == 6)
                {
                    pbxGubbe.Top = 6;
                    tbxVisa.Text = "??????";
                    tbxGissa.Enabled = true;
                    svar = tbxSvar.Text;  // <---------- use svar here
                    tbxSvar.Text = "";
                }
                else
                {
                    
                    tbxVisa.Text = "";
                }
    
            }
    
            private void TbxGissa_TextChanged(object sender, EventArgs e)
            {
                if (tbxGissa.Text == "") return;
                string gissning = tbxGissa.Text;
                int index = svar.indexOf(gissning); // <---------- ...and here
    
            }
        }
