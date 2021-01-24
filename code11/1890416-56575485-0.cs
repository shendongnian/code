    public string CreateCopyEnvelopeAndSendEmail(string EnvelopeID, string url)  
    {
       var docuSignClient = new DocuSignClient(this.DocuSignCredentials);
       var accountId = docuSignClient.AccountId;
       EnvelopesApi envelopesApi = new EnvelopesApi();           
       
        var options = new ReturnUrlRequest();
        options.ReturnUrl = url;
            
        var envDef = new EnvelopeDefinition()
            {               
                Status = "created",
                EnvelopeId = EnvelopeID
            };   
          
        EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountId, envDef);
       // create the sender view
       ViewUrl recipientView = envelopesApi.CreateSenderView(accountId,
             envelopeSummary.EnvelopeId, options);
       return recipientView.Url.ToString();
     }
