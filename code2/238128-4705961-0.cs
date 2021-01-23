    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0312) {
            int id = m.WParam.ToInt32();
            MessageBox.Show(string.Format("Hotkey #{0} pressed", id);
        }
        base.WndProc(ref m);
    }
