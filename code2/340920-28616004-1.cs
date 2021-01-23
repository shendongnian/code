    public partial class MainForm : BaseForm
    {
        private void button1_Click_1(object sender, EventArgs e)
        {
                ColorDialog colorDlg = new ColorDialog();
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.FormsBackgroundColor= colorDlg.Color;
                    Properties.Settings.Default.Save();
                    this.BackColor = colorDlg.Color;
                }
            }    
     }
