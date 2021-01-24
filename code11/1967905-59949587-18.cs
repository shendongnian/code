    public partial class Form1: Form
    {
        // If an Instance of the UC has been added in the Form's Designer,
        // use that instance reference instead 
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
