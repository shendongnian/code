                bool success; //string responseString;
                // Anything unlocks the component and begins a fully-functional 30-day trial.
                success = imap.UnlockComponent("Anything for 30-day trial");
                if (success != true)
                {
                    MessageBox.Show(imap.LastErrorText);
                    return;
                }
                imap.Port = 993;
                imap.Ssl = true;
                // Connect to an IMAP server.
                success = imap.Connect("servername.na.company.org");
                if (success != true)
                {
                    MessageBox.Show(imap.LastErrorText);
                    return;
                }
                success = imap.IsConnected() ;
                MessageBox.Show("suc"+success);
                success = imap.Login("username", "pwd");
                
                if (success != true)
                {
                    MessageBox.Show(imap.LastErrorText);
                    return;
                }
                // Select an IMAP mailbox
                success = imap.SelectMailbox("firstname.lastname@xxxx.com");
                if (success != true)
                {
                    MessageBox.Show(imap.LastErrorText);
                    return;
                }
