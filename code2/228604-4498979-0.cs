    private void SetLabelText(string message)
    {
                if (label.InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => SetLabelText(message)
                               ));
                }
                else
                {
                    label.Text = message;
                }
    }
