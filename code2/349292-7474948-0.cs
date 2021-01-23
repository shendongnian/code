    private void SetButtonText(string newText) {
        if (btn.InvokeRequired) {
            Invoke((MethodInvoker)(() => SetButtonText(newText)));
        }
        else {
            btn.Text = newText;
        }
    }
