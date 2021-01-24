    public void checkstatus()
    {
    if(textbox1.Text.Trim()=="" || textbox2.Text.Trim()=="" || textbox3.Text.Trim()=="")
    {
     MessageBox.Show("Some Textboxes are empty");
    }
    else
    {
     progessbar.Start();
    }
}
