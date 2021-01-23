    try
    {
        string s = textBox2.Text;
        string[] f = s.Split(',');
        
        for (int i = 0; i<f.Length; i++)
        {
            MailMessage message = new MailMessage(); // Create instance of message
            message.To.Add(f[i]); // Add receiver
            message.From = new System.Net.Mail.MailAddress(c);// Set sender .In this case the same as the username
            message.Subject = label3.Text; // Set subject
            message.Body = richTextBox1.Text; // Set body of message
            client.Send(message); // Send the message
            message = null; // Clean up
        }
        
    }
        
    catch (Exception ex)
    {
        
        MessageBox.Show(ex.Message);
    }
