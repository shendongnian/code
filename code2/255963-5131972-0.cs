        private void sessionText()
        {
            try
            {
                using (System.IO.TextReader r = new System.IO.StreamReader("saved.txt"))
                {
                  this.textBox1.Text = r.ReadLine();
                  this.textBox2.Text = r.ReadLine();
                  this.textBox3.Text = r.ReadLine();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception " +x);
            }
        }
