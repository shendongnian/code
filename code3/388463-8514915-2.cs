    public class MainForm : Form
    {
        Form loginform;
        public Active(Form loginForm)
        {
            this.loginForm = loginForm;
        }
        public void CloseForms()
        {
            loginForm.Close();
            this.Close();
        }
    }
    //from the LOGIN form
    if (access)
        {
            Main_Form mainForm = new Main_Form();
            mainForm.Visible = true;
             mainForm.Activate(this); //this is a reference to the current form. LOGIN in this case
    
         }
