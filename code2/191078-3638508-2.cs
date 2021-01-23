    public partial class Form1 : Form, IDataReceiver
    {
        
        private void Button_Click(object sender, EventArgs e)
        {
            // create a module intstance, passing this form as parameter
            var module = new SomeModule(this);
            module.DoSomeWork();
        }
        public void SetData(string data)
        {
            // use the data that is received
            txtSomeTextBox.Text = data;
        }
        // the rest of the form code left out to keep it short
    }
