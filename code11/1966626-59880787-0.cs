     int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
          if(!PostBack)
          {
                  if (counter == 0)
                  {
                       additional_Tabe.Visible = false;
                       counter += 1;
                  }
           }
          
    }
