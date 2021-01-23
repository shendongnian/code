    protected override void OnFormClosing(FormClosingEventArgs e)
    {
    if(!HasValidData())
       e.Cancel = true;
         
    base.OnFormClosing(e);
    }
