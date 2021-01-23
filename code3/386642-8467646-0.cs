Form2.cs
     public partial class ViewCars : Form
        {
            Form1 mainForm;
            public ViewCars (Form1 MainForm)
            {
               this.mainForm = MainForm;
            }
        }
    
         private void LoginButton_Click(object sender, EventArgs e)
         {
             mainForm.menuStrip.Visible = false;
         }
