    private static bool ValidateRemoteCertificate(
      object sender,
      X509Certificate certificate,
      X509Chain chain,
      SslPolicyErrors policyErrors)
    {
        // Logic to determine the validity of the certificate
         // return boolean
    }
    
    // allows for validation of SSL conversations
                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(
                    ValidateRemoteCertificate
                );
    
    HtmlElementCollection ellements = webBrowser.Document.GetElementsByTagName("input");
    foreach (HtmlElement ellement in ellements)
    {
        if (ellement.OuterHtml == "<INPUT onclick=\"this.value = 'Submitted'\" value=\" Login \" type=submit>")
        {
            ellement.InvokeMember("click");
            this.DialogResult = DialogResult.OK;
            break;
        }
    }
    
            
