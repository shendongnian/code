    protected void Timer1_Tick(object sender, EventArgs e)
        {
    
            Label2.Text = Convert.ToString((Convert.ToInt32(Label2.Text) - 1)/60);
            if (Convert.ToInt32(Label2.Text) == 0)
                Response.Redirect("~/Default2.aspx");
        }
