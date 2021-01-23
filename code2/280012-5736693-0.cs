     public class Form1 : Form
     {
        bool saveFlag;
        private void Form1_Load(object sender, EventArgs ev)
        { FormClosing += closeNpForm;
        }
  
        private void closeNpForm(object sender, FormClosingEventArgs e)
        {
            if (!saveFlag)
            {
                if (MessageBox.Show("Do you want to save the text entered?", "Save Changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = true;
                    saveFlag = true;
                    this.Close();
                }
            }
         }
      }
