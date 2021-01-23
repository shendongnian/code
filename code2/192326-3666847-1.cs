    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (Program.FullClose==false)
        {
           e.Cancel = true;
           this.Visible = false;
           Program.f2.Show();
        }
    }
