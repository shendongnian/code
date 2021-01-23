    //add a label to the flow control panel when you double click on an item
    private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = listBox1.SelectedItem.ToString();
            label.Click += new EventHandler(label_Click);
            label.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label);
            label.BringToFront();
        }
        //Will remove the label if you click on it.
        void label_Click(object sender, EventArgs e)
        {
            ((Label)sender).Click -= new EventHandler(label_Click);
            ((Label)sender).Dispose();
        }
