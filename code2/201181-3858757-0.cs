    private delegate void ControlUpdateTextHandler(TextBox ctrl, string text);
    public void UpdateControlText(TextBox ctrl, string text)
    {
        if (ctrl.InvokeRequired)
        {
            ctrl.BeginInvoke((ControlUpdateTextHandler)UpdateControlText, ctrl, text);
        }
        else
            ctrl.Text = text;
    }
