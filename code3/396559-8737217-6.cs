    public class MyForm : Form
    {
        public void SetSomeText ()
        {
            var control = this.FindControlRecursively<TextBox> ("myTextboxName");
            if (control != null)
            {
                control.Text = "I found it!";
            }
            // Or...
            var control2 = this.FindControlRecursively ("myTextboxName2") as TextBox;
            if (control != null)
            {
                control2.Text = "I found this one, also!";
            }
        }
    }
