    public static class ThreadSafeHelpers {
            public static void SetText(Label varLabel, string newText) {
                if (varLabel.InvokeRequired) {
                    varLabel.BeginInvoke(new MethodInvoker(() => SetText(varLabel, newText)));
                } else {
                    varLabel.Text = newText;
                }
            }
    }
