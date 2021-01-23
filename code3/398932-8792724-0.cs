    protected void Timer1_Tick(object sender, EventArgs e)
    {
        
        if (partialPostBackCount > 5 )
            {
               lblPostbackType.Text = "Partial Postback:: " + 
                                       partialPostBackCount.ToString();
               //Timer1.Enabled = false; //if you don't want it to continue
            }
            else
            {
                partialPostBackCount = partialPostBackCount + 1;
                Label1.Text = Label1.Text + "+";
            }
    }
