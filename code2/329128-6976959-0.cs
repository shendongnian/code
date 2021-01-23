    private void button13_Click(object sender, EventArgs e)
    {
       if(debugMode)
       {
          button13.ForeColor = Color.Black;
          debugMode = false;
       }
       else
       {
          button13.ForeColor = Color.Red;
          debugMode = true;
       }
    }
