    private async void RemindButton_Click(object sender, EventArgs e)
    {
        // ... other code
        var messageDelay = reminderTime - DateTime.Now;
        _reminderTokenSource = new CancellationTokenSource();
        
        await Task.Delay(messageDelay, _reminderTokenSource.Token);
        MessageBox.Show(FinalMessage);  
    }
