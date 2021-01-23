    protected override bool ProcessCmdKey(ref Message message, Keys keys)
    {
        switch (keys)
        {
            case Keys.F2 | Keys.Control:
                //Process action here.
                return false;
        }
     
        return false;
    }
