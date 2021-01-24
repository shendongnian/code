    protected voud btnLogin_Click (object sender, EventArgs e)
    {
       int status = Convert.ToInt32(cbLogin.Value);
    
       if (status == 1)
         { 
            Form1 frm1 = new Form1(); //Form 1 the name of the form which you want to open.
            frm1.Show();
            this.Hide()
         }
       else if (status == 2)
         {
            From2 frm2 = new Form2(); //Form 2 the name of the form which you want to open.
            frm2.Show();
            this.Hide();
         }
