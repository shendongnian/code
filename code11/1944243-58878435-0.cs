protected void LbUnCheck(object sender, EventArgs e)
{
        LinkButton lb = (LinkButton)sender;
        CheckBox cb = (CheckBox)LVCheckBoxes.FindControl(lb.ToolTip);
        
        // cb.CheckedChanged += checkBoxCheck; // REMOVE THIS LINE
        
        cb.Checked = false;
        checkBoxCheck(null, null); // NOTICE THIS IS AFTER SETTING cb.Checked = false;
}
protected void checkBoxCheck(object sender, EventArgs e)
{
   //Do something
}
