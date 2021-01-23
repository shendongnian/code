           void AddText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((Action<string>)AddText, text);
            }
            textBox1.Text = text;
        }
