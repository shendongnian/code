    	//ASP.NET MVC action method... But you can easily modify the code for Web-forms etc.
		public ActionResult SamlConsume()
		{
			//specify the certificate that your SAML provider has given to you
			string samlCertificate = @"-----BEGIN CERTIFICATE-----
		BLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAH123543==
		-----END CERTIFICATE-----";
			Saml.Response samlResponse = new Response(samlCertificate);
			samlResponse.LoadXmlFromBase64(Request.Form["SAMLResponse"]); //SAML providers usually POST the data into this var
			if (samlResponse.IsValid())
			{
				//WOOHOO!!! user is logged in
				//YAY!
				
				//Some more optional stuff for you
				//lets extract username/firstname etc
				string username, email, firstname, lastname;
				try
				{
					username = samlResponse.GetNameID();
					email = samlResponse.GetEmail();
					firstname = samlResponse.GetFirstName();
					lastname = samlResponse.GetLastName();
				}
				catch(Exception ex)
				{
					//insert error handling code
					//no, really, please do
					return null;
				}
				
				//user has been authenticated, put your code here, like set a cookie or something...
				//or call FormsAuthentication.SetAuthCookie() or something
			}
		}
