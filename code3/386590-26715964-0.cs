    protected override void WndProc(ref Message m)
    {
        if ((m.Msg == 0x20) && (m.LParam.ToInt32() == 0x0201FFFE))
        {
            AdvertisingForm.CloseInstance();
        }
        else
        {
            base.WndProc(ref m);
        }
    }
