    //"checked" and "notChecked" are the images names.
    private void button1_Click(object sender, EventArgs e)
    {
       if(checkedFlag == true)
       {
        button1.BackgroundImage = Properties.Resources.notchecked;
        checkedFlag = false;
       }     
       else
       {
        button1.BackgroundImage = Properties.Resources.checked;
        checkedFlag = true;
       }
    }
