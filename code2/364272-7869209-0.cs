    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
	      Timer1.Interval = 1000;
	      Timer1.Start();
    }
    private void Timer1_Tick(System.Object sender, System.EventArgs e)
    {
	        this.Label1.Text = DateTime.Now.ToString("hh/mm/ss");
     }
