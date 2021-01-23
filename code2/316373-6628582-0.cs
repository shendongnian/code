      private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime myData = new DateTime();
            if (DateTime.TryParse(this.textBox1.Text,out myData))
            {
                // your filed db = myData
            }
        }
