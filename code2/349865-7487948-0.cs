    private void Form1_Load(object sender, EventArgs e)
    {
      listBox1.MouseDown += new MouseEventHandler(listBox1_MouseDown);
    }
    void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        MessageBox.Show("Right Click");
      }
    }
