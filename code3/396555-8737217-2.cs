    public class MyForm : Form
    {
        public void SetSomeText ()
        {
            var control = this.FindControlRecursively<TextBox> ("myTextboxName");
            if (control != null)
            {
                control.Text = "I found it!";
            }
        }
    }
