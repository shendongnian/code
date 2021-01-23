    public class Form1 : Form
    {
        public void ShowForm2()
        {
            myButton.Enabled = false;
            var f2 = new Form2();
            f2.FormClosed += HandleForm2Closed;
            f2.Show();
        }
    
        private void HandleForm2Closed(Object sender, FormClosedEventArgs e)
        {
            myButton.Enabled = true;
        }
    }
