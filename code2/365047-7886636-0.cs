    class Form2
    {
        public string ReturnedText = "";
    
        private void button1_Click(object sender, EventArgs e)
        {
            ReturnedText = textbox1.Text;
            Close();
        }
    }
