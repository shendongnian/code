    private void HookUpEventHandlers()
    {
        var someListOfPicBoxes = GetPicBoxList();
        foreach(var p in someListOfPicBoxes)
        {
            p.Click += p_Click;
        }
    }
    
    private void p_Click(object sender, EventArgs e)
    {
        // this is the PictureBox that was clicked
        var pb = (PictureBox)sender;
    }
