    private void Form1_Load(object sender, EventArgs e)
    {
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      for (int i = 0; i <= 100; i++)
      {
        progressBar1.ForeColor = Color.Blue;
        progressBar1.Value = i;
        System.Threading.Thread.Sleep(40);
        if (progressBar1.Value == 100)
        {
          Form12 f1 = new Form12();
          f1.Show();
        }
      }
      this.Opacity = 0;
      this.Visible = false;
    }
