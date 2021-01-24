ComponentSpace.SAML2 Verbose: 0 : 9:19:44 PM: Missing form variable SAMLResponse
ComponentSpace.SAML2 Verbose: 0 : 9:19:44 PM: Exception: ComponentSpace.SAML2.SAMLBindingException: The form is missing the variable SAMLResponse
**Resolution**:<br>
The log of SAML exception states that the form/format of SAML Response is incorrect.
[Creating SAML Response for SSO](https://mukarrammukhtar.wordpress.com/single-sign-on-p-1/) provides the following sample code to demonstrate how to generate SAML Response using ComponentSpace libray.
        // Create a SAML response with the user's local identity.
        private SAMLResponse CreateSAMLResponse()
        {
            //Trace.Write("IdPreating SAML response");
           SAMLResponse samlResponse = new SAMLResponse();
            samlResponse.Destination = strAssertionConsumerServiceURL;
            Issuer issuer = new Issuer(CreateAbsoluteURL("~/"));
            samlResponse.Issuer = issuer;
            samlResponse.Status = new Status(SAMLIdentifiers.PrimaryStatusCodes.Success, null);
            SAMLAssertion samlAssertion = new SAMLAssertion();
            samlAssertion.Issuer = issuer;
            //Subject subject = new Subject(new NameID(User.Identity.Name));
            Subject subject = new Subject(new NameID());
            SubjectConfirmation subjectConfirmation = new SubjectConfirmation(SAMLIdentifiers.SubjectConfirmationMethods.Bearer);
            SubjectConfirmationData subjectConfirmationData = new SubjectConfirmationData();
            subjectConfirmationData.Recipient = strAssertionConsumerServiceURL;
            subjectConfirmation.SubjectConfirmationData = subjectConfirmationData;
            subject.SubjectConfirmations.Add(subjectConfirmation);
            samlAssertion.Subject = subject;
            samlAssertion.SetAttributeValue("MemberId", this.txtMemberId.Text);
            samlAssertion.SetAttributeValue("Name", this.txtName.Text);
            samlAssertion.SetAttributeValue("Phone", this.txtPhone.Text);
            AuthnStatement authnStatement = new AuthnStatement();
            authnStatement.AuthnContext = new AuthnContext();
            authnStatement.AuthnContext.AuthnContextClassRef = new AuthnContextClassRef(SAMLIdentifiers.AuthnContextClasses.Password);
            samlAssertion.Statements.Add(authnStatement);
           samlResponse.Assertions.Add(samlAssertion);
            return samlResponse;
        }
        // Send the SAML response to the SP.
        private void SendSAMLResponse(SAMLResponse samlResponse, string relayState)
        {
            // Serialize the SAML response for transmission.
            XmlElement samlResponseXml = samlResponse.ToXml();
            // Sign the SAML response.
           X509Certificate2 x509Certificate = (X509Certificate2)Application["IdPX509Certificate"];
            SAMLMessageSignature.Generate(samlResponseXml, x509Certificate.PrivateKey, x509Certificate);
          IdentityProvider.SendSAMLResponseByHTTPPost(Response, strAssertionConsumerServiceURL, samlResponseXml, relayState);
        }
