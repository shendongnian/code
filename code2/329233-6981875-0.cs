        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!menuClosed)
                listBox1.Items.Add("new item added - " + DateTime.Now.ToLongTimeString());
        }
