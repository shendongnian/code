    private void EnterKeyAction()
    {
       // Search...
    }
    private void btnEnter_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (e.KeyChar == (char)Keys.Return)
              EnterKeyAction();    
    }
    private void btnEnter_Click(object sender, EventArgs e)
    {
         EnterKeyAction();
    }
