    public void GroupBox_LostFocus(object sender, EventArgs e)
    {
        if (Button.Focused == true) 
        {
           clean_form_button_click(sender, e);
        }
        else
        {
          // check all controls in the GroupBox were filled
        }
    }
