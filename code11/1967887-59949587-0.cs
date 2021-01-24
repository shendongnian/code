    public partial class Form1: Form
    {
        // To reproduce the Form Designer's generated instance of UCModule2
        UCModule2 ucModule2 = new UCModule2();
    
        private void Form1_Load(object sender, EventArgs e)
        {
            ucModule2.Location = new Point(100, 100);
            this.Controls.Add(ucModule2);
            ucModule2.SetForm(typeof(Form2));
        }
    
        private void UsrCtrlDialog_Click(object sender, EventArgs e)
        {
            ucModule2?.FormInstance?.Close();
        }
    }
