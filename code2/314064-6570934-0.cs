    private static void SetText(TextBox tb, string text)
    {
        if (tb.InvokeRequired)
        {
            var stDelegate = new StDelegate(SetText);
            tb.Invoke(stDelegate, new object[] { tb, text });
        }
        else
        {
            tb.Text = text;
        }
    }
