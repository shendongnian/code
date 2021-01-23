    string outputText;
        void StarterBackup_X64_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
                outputTextBox.Dispatcher.Invoke(new Action(() => { outputTextBox.Text += e.Data; outputText = outputTextBox.Text; }), null);
                SplitTextIntoLines(outputText, 1);
        }
