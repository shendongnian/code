    private async void RemindButton_Click(object sender, EventArgs e)
    {
        string FinalMessage = "";
        //add text from the radio buttons 
        // ...
        FinalMessage += " work from ";
        string Teacher_Name = TeacherNameTextBox.Text;
        FinalMessage += Teacher_Name + " is due on ";
        DateTime reminderTime = DateTimePicker.Value;
          
        FinalMessage += {reminderTime:yyyy/MM/dd 'at' HH:mm}; // will print 2019/11/25 at 12:23
        FinalMessage += " and is about " + DescriptionTextBox.Text;
        // calculate delay from now
        var messageDelay = reminderTime - DateTime.Now;
       
        await Task.Delay(messageDelay);
        MessageBox.Show(FinalMessage);       
    }
