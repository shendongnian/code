        OpenIdRelyingParty openid = new OpenIdRelyingParty();
        protected void Page_Load(object sender, EventArgs e)
        {
            var response = openid.GetResponse();
            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        if (this.Request.Params["openid.ext1.value.alias1"] != null)
                        {
                            Response.Write(this.Request.Params["openid.ext1.value.alias1"]);
                            Response.Write(this.Request.Params["openid.ext1.value.alias2"]);
                        }
                        else {
                            Response.Write("Alias wrong");
                        }
                        break;
                }
            }
        }
         protected void loginButton_Click(object sender, EventArgs e)
        {
            var openidRequest = openid.CreateRequest(openIdBox.Text);
            var fetch = new FetchRequest();
            fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
            fetch.Attributes.AddRequired(WellKnownAttributes.Name.FullName);
            openidRequest.AddExtension(fetch);
            openidRequest.RedirectToProvider();
        }
