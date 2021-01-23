    protected void add_button(Button btn)
    {
       try
       {
            panel1.Controls.Add(btn); // Add the control to the container on a page
       }
       catch (Exception ee)
       {
             lblError.Text = ee.Message.ToString();
       }
    }
