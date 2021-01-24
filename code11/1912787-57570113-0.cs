    if (!string.IsNullOrEmpty(text))
    {
        timer1.Enabled = false; // stop the timer
        // do code here that can take some time...
        GetAnswer(Clipboard.GetText(TextDataFormat.UnicodeText));
        Clipboard.Clear();
        timer1.Interval = 15000; // reset the timer
        timer1.Enabled = true;   // and start it again
    }
