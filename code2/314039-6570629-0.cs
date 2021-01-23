     private void DoUpdate(object s, EventArgs e)
        {
            Thread.Sleep(30);
            string data = port.ReadExisting() + port.ReadExisting();
            if(data.Trim().Count() < 3)
                MessageBox.Show("data = " + data);
            else
            try
            {    
                richTextBox1.Text = data.Trim().Remove(0, 3);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }
        }
