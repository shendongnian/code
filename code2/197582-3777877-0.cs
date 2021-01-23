    private void MyFancyCheckChanged(CheckBox sender, EventArgs e)
    {
      // do stuff
    }
    
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      MyFancyCheckChanged((CheckBox) sender, e);
    }
