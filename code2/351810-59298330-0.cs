    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        MSG l_Msg;
        ushort l_Scancode;
        PresentationSource source = e.InputSource;
        var l_MSGField = source.GetType().GetField("_lastKeyboardMessage", BindingFlags.NonPublic | BindingFlags.Instance);
        l_Msg = (MSG)l_MSGField.GetValue(source);
        l_Scancode = (ushort)(l_Msg.lParam.ToInt32() >> 16);
        m_Host.KeyData(l_Scancode);
    }
