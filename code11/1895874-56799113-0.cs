    masterCandidateCasesListToDisplay = await Controllers.CandidateCaseController.GetAllCandidates();
    selectedCandidate = masterCandidateCasesListToDisplay.Where(x => x.BatchNumber == selectedBatch && x.RejectionReason != null).ToList();
    
    if (masterCandidateCasesListToDisplay.Count > 0)
    {
    
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    
        string requestorName0 = selectedCandidate[0].RequestorInfo.DisplayName;
        string requestorEmail0 = selectedCandidate[0].RequestorInfo.Email;
    
        MailMessage mailMessage = new MailMessage();
        MailAddress to = new MailAddress(requestorEmail);
    
        mailMessage.From = new MailAddress("NoReply_FTA@courts.state.mn.us");
        mailMessage.To.Add(to);
        mailMessage.Subject = "FTA Case Reset Notice";
        mailMessage.Body = message;
        mailMessage.IsBodyHtml = true;
    
        string ccEmailAddress = Authentication.GetADEmail();
        if (ccEmailAddress.Length > 0)
        {
            MailAddress ccto = new MailAddress(ccEmailAddress);
            mailMessage.CC.Add(ccto);
        }
    
        foreach (ListViewItme item in AdditionalStaffEmailListBox.SelectedItems)
        {
            candidate = masterCandidateCasesListToDisplay.First(x => x.RequestorInfo.DisplayName == item.Value);
    
            requestorName = candidate.RequestorInfo.DisplayName;
            requestorEmail = candidate.RequestorInfo.Email;
    
            if (requestorEmail0 == requestorEmail)
            {
                continue;
            }
            
            MailAddress to = new MailAddress(requestorEmail);
            mailMessage.To.Add(to);
    
            if (ccEmailAddress.Length > 0)
            {
                MailAddress ccto = new MailAddress(ccEmailAddress);
                mailMessage.CC.Add(ccto);
            }
    
            smtpClient.Send(mailMessage);
            MessageBox.Show("An email has been sent to " + requestorName, "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
