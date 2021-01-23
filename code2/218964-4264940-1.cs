    public class form1:System.Windows.Forms.Form
    {
        public form1()
        {
        }
        public form1(string message,string buttonText1,string buttonText2)
        {
           lblMessage.Text = message;
           button1.Text = buttonText1;
           button2.Text = buttonText2;
        }
    }
    // Write code for button1 and button2 's click event in order to call 
    // from any where in your current project.
    // Calling
    Form1 frm = new Form1("message to show", "buttontext1", "buttontext2");
    frm.ShowDialog();
