    var workStartTime = TimeSpan.Parse(workStart.Text);
    var workEndTime = TimeSpan.Parse(workEnd.Text);
    foreach (var button in allButtons)
    {
        var buttonTime = TimeSpan.Parse(button.Text);
        button.Enabled = buttonTime >= workStartTime && buttonTime <= workEndTime;
    }
