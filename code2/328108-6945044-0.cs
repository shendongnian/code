    string to = toTextBox.Text;
    string subject = subjectTextBox.Text;
    string cc = ccTextBox.Text;
    string bcc = bccTextBox.Text;
    string files = filenames.ToArray();
    
    Task.Factory.StartNew(() => SendMail(to, subject,BodyEditor.ContentHtml, files, cc, bcc));
