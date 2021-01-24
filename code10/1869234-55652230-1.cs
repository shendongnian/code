    public static MsgDlgResult Show(string message, string title, Buttons buttons, IconImage icon)
    {
        if (MainForm.InvokeRequired)
        {
            MainForm.Invoke((MethodInvoker)delegate { ShowSafe(message, title, buttons, icon); });
        }
        else
        {
            ShowSafe(message, title, buttons, icon);
        }
    }
