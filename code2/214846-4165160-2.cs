    protected override void WndProc(ref Message m)
    {
        if(m.Msg == WM_SYSCOMMAND)
        {
            switch(m.WParam.ToInt32())
            {
                case IDM_CUSTOMITEM1 : 
                    MessageBox.Show("Clicked 'Item 1'");
                    return;
                case IDM_CUSTOMITEM1 :
                    MessageBox.Show("Clicked 'item 2'");
                    return;
                default:
                    break;
            } 
        }
        base.WndProc(ref m);
    }
