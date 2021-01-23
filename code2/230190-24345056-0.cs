      private void button1_Click(object sender, EventArgs e)
        {
           System.Threading.Thread.Sleep(5000);
           SendKeys.Send(send_text);
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            send_text = textBox1.Text;            
        }
