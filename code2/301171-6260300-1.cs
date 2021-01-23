    public partial class Form1
    {
        ...
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            newform.ShowDialog();
            // We get here when newform's DialogResult gets set
            this.Show();
        }
    }
    public partial class Form2
    {
        ...
        private void button1_Click(object sender, EventArgs e)
        {
            // This hides the form, and causes ShowDialog() to return in your Form1
            this.DialogResult = DialogResult.OK;
        }
    }
