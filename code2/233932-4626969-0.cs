    private void [YourFormName]_KeyDown(object sender, KeyEventArgs e)
    {
        Control nextControl ;
        //Checks if the Enter Key was Pressed
        if (e.KeyCode == Keys.Enter) 
        {
            //If so, it gets the next control and applies the focus to it
            nextControl = GetNextControl(ActiveControl, !e.Shift);
            if (nextControl == null)
            {
                nextControl = GetNextControl(null, true);
            }
            nextControl.Focus();
            //Finally - it suppresses the Enter Key
            e.SuppressKeyPress = true;
        }
    } 
