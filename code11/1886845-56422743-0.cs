    private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    private void T_Elapsed(object sender, EventArgs e)
        {
            if (true)
            {
                myFunction();
                t.Enabled = false;
                t.Stop();
            }
        }
     private void myFunction2()
        {
            t.Interval = int.Parse(textBox1.Text);
            t.Tick += T_Elapsed;
            t.Start();
        }
        private void myFunction()
        {
            t.Enabled = false;
            t.Stop();
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();}
