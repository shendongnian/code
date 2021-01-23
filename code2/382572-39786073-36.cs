    bool IsOpenFileDialog = false;
    private void openDialog_Click(object sender, EventArgs e)
    {
        IsOpenFileDialog = true;
        openFileDialog1.ShowDialog();
        IsOpenFileDialog = false;
    }
    uint _lastDialogHandle = 0;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (!IsOpenFileDialog) return;
        if (m.Msg == 289) //Notify of message loop
        {
            try
            {
                uint dialogHandle = (uint)m.LParam;	//handle of the file dialog
                if (dialogHandle != _lastDialogHandle) //only when not already changed
                {
                    _lastDialogHandle = dialogHandle;
                    SendKeys.SendWait("+{TAB}");
                    SendKeys.SendWait("+{TAB}");   
                    SendKeys.SendWait(EscapeSendKeySpecialCharacters("temp.xls"));
                    //Or try via Win32
                    //List<string> childWindows = GetDialogChildWindows(dialogHandle);
                    //TODO set ListView Item
                }
            }
            catch (Exception ex) {}
        }
    }
    private string EscapeSendKeySpecialCharacters(string sentence)
    {
        sentence = sentence.Replace("+", "{+}");
        sentence = sentence.Replace("^", "{^}");
        sentence = sentence.Replace("%", "{%}");
        sentence = sentence.Replace("~", "{~}");
        sentence = sentence.Replace("(", "{(}");
        sentence = sentence.Replace(")", "{)}");
        return sentence;
    }
