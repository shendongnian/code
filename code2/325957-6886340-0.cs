    if (IsRunning == true)
    {
        bool checkbox1Checked;
        string textBox6Text;
        string textBox7Text;
        string textBox3Text;
        string textBox1Text;
        string textBox4Text;
        string richTextBox1Text;
        string textBox5Text;
        MethodInvoker getValues = new MethodInvoker(delegate()
        {
            checkbox1Checked = checkbox1.Checked;
            textBox6Text = textBox6.Text;
            textBox7Text = textBox7.Text;
            textBox3Text = textBox3.Text;
            textBox1Text = textBox1.Text;
            textBox4Text = textBox4.Text;
            richTextBox1Text = richTextBox1.Text;
            textBox5Text = textBox5.Text;
        });
        if (this.InvokeRequired)
        {
            this.Invoke(getValues);
        }
        else
        {
            getValues();
        }
        if (checkBox1Checked != true)
        {
            SmtpClient client = new SmtpClient(comboBox1Text);
            client.Credentials = new NetworkCredential(textBox6Text, textBox7Text);
            MailMessage message = new MailMessage();
            message.From = new MailAddress(textBox3Text, textBox1Text);
            message.Subject = textBox4Text;
            //message.Body = richTextBox1Text;
            if (textBox5Text != "")
            {
                message.Attachments.Add(new Attachment(textBox5Text));
            }
            foreach (string eachmail in list)
            {
                if (IsRunning == true)
                {
                    try
                    {
                        message.To.Add(eachmail);
                        client.Send(message);
                        
                        MethodInvoker addToListBox = new MethodInvoker(delegate()
                        {
                            listBox1.Items.Add("Successfully sent the message to  : " + eachmail);
                        }); 
                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(addToListBox);
                        }
                        else
                        {
                            addToListBox();
                        }
                        success++;
                    }
                    catch
                    {
                        MethodInvoker addToListBox = new MethodInvoker(delegate()
                        {
                            listBox1.Items.Add("Failed to send the message to  : " + eachmail);
                        });
  
                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(addToListBox);
                        }
                        else
                        {
                            addToListBox();
                        }
                        failed++;
                    }
                    message.To.Clear();
                    total++;
                    Thread.Sleep(15);
                    
                    MethodInvoker updateSatatus = new MethodInvoker(delegate()
                    {
                        label18.Text = total.ToString();
                        label19.Text = success.ToString();
                        label21.Text = failed.ToString();
                    });
                    if (this.InvokeRequired)
                    {
                        this.Invoke(updateSatatus);
                    }
                    else
                    {
                        updateSatatus();
                    }
                }
                else
                {
                    break;
                }
            }
            IsRunning = false;
            if (button3.InvokeRequired)
            {
                button3.Invoke(new MethodInvoker(delegate() { button3.Text = "Send"; } ));
            }
            else
            {
                button3.Text = "Send";
            }
        }
    }
