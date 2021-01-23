    //bad way to send emails to all people in list, that will freeze your UI
    foreach (String to in toList)
    {
        bool hasSent = SendMail(from, "password", to, SubjectTextBox.Text, BodyTextBox.Text);
        if (hasSent)
        {
            OutPutTextBox.appendText("Sent to: " + to);
        }
        else
        {
            OutPutTextBox.appendText("Failed to: " + to);
        }
    } 
    //good way using Task class which won't freeze your UI
    string subject = SubjectTextBox.Text;
    string body = BodyTextBox.Text;
    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    List<Task> mails = new List<Task>();
    foreach (string to in toList)
    {
        string target = to;
        var t = Task.Factory.StartNew(() => SendMail(from, "password", target, subject, body))
        .ContinueWith(task =>
        {
            if (task.Result)
            {
                OutPutTextBox.appendText("Sent to: " + to); 
            }
            else
            {
                 OutPutTextBox.appendText("Failed to: " + to); 
            }
         }, ui);
     }
