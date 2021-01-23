            [Test]
        public void SendMandrillTaggedEmail()
        {
            string SMTPUsername = _config( "MandrillSMTP_Username" );
            string APIKey = _config( "MandrillSMTP_Password" );
            using( var client = new MandrillSmtpClient( SMTPUsername, APIKey ) ) {
                MandrillMailMessage message = new MandrillMailMessage() 
                { 
                    From = new MailAddress( _config( "FromEMail" ) ) 
                };
                string to = _config( "ValidToEmail" );
                message.To.Add( to );
                message.MandrillHeader.PreserveRecipients = false;
                message.MandrillHeader.Tracks.Add( ETrack.opens );
                message.MandrillHeader.Tracks.Add( ETrack.clicks_all );
                
                message.MandrillHeader.Tags.Add( "NewsLetterSignup" );
                message.MandrillHeader.Tags.Add( "InTrial" );
                message.MandrillHeader.Tags.Add( "FreeContest" );
                
                
                message.Subject = "Test message 3";
                
                message.Body = "love, love, love";
                client.Send( message );
            }
        }
