    public static MsgDlgResult Show(string message, string title, Buttons buttons, IconImage icon)
    {
        if (!MainForm.IsHandleCreated) return default(MsgDlgResult);
        if (MainForm.InvokeRequired)
        {
            MsgDlgResult result = default(MsgDlgResult);
            Thread.MemoryBarrier();
            MainForm.Invoke((MethodInvoker)delegate { result = ShowSafe(message, title, buttons, icon); });
            Thread.MemoryBarrier();
            return result;
        }
        else
        {
            return ShowSafe(message, title, buttons, icon);
        }
    }
