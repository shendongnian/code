    string recipient = toTextBox.Text;
    string subject = subjectTextBox.Text;
    string html = BodyEditor.ContentHtml;
    string cc = ccTextBox.Text;
    string bcc = bcTextBox.Text();
    Task.Factory.StartNew(() => SendMail(recipient,
                                         subject,
                                         html,
                                         filenames.ToArray(),
                                         cc,
                                         bcc));
