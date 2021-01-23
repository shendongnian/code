    protected override void WndProc(ref Message m)
    {
        if ((m.Msg == 0x20) && (m.LParam.ToInt32() == 0x0201FFFE) && (ActiveForm == AdvertisingForm.Instance))
        {
            AdvertisingForm.CloseInstance();
        }
        else
        {
            base.WndProc(ref m);
        }
    }
