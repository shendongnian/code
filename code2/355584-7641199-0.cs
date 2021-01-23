    public void SetWaitLabelText(string text) {
        Invoke(new Action<string>(SetWaitLabelText2), text);
    }
    void SetWaitLabelText2(string text) {
        lblWaitMessage.Text = text;
    }
