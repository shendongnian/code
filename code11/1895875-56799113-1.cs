    private async void SendEmail(int selectedBatch)
    {
        string message = "The following records have been prepped for processing.  Valid cases will be processed.{0}{1}{2}";
        string requestorName = string.Empty;
        string requestorEmail = string.Empty;
        List<GetCandidateCaseModel> masterCandidateCasesListToDisplay = new List<GetCandidateCaseModel>();
        try
        {
            masterCandidateCasesListToDisplay = await Controllers.CandidateCaseController.GetAllCandidates();
            var selectedCandidate = masterCandidateCasesListToDisplay.Where(x => x.BatchNumber == selectedBatch && x.RejectionReason != null).ToList();
    
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
            
                    to = new MailAddress(requestorEmail);
                    mailMessage.To.Add(to);
                    ccEmailAddress = Authentication.GetADEmail();
    
                    if (ccEmailAddress.Length > 0)
                    {
                        MailAddress ccto = new MailAddress(ccEmailAddress);
                        mailMessage.CC.Add(ccto);
                    }
    
                    MessageBox.Show("An email has been sent to " + requestorName, "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                smtpClient.Send(mailMessage);
            }
            else
            {
                MessageBox.Show("No Requestor was found.  Unable to send an email.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            string errorMsg = string.Format("An error has occured in {0}. \nException:\n{1}", "SubmitButton_Click()", ex.Message);
            MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
