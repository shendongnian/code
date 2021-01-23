    protected override void WndProc(ref Message m) {
        if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID) {
            // My hotkey has been typed
            // Do what you want here
            // ...
        }
        base.WndProc(ref m);
    }
