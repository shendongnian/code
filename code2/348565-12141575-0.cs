	class SomeClass
	{
		private string clientID         = "XXXXXXXXX.apps.googleusercontent.com";
		private string clientSecret     = "MY_CLIENT_SECRET";
		private string refreshToken     = "MY_REFRESH_TOKEN";
		private string primaryCal       = "MY_GMAIL_ADDRESS";
		private void button2_Click_1(object sender, EventArgs e)
		{
			try
			{
				NativeApplicationClient client = new NativeApplicationClient(GoogleAuthenticationServer.Description, this.clientID, this.clientSecret);
				OAuth2Authenticator<NativeApplicationClient> auth = new OAuth2Authenticator<NativeApplicationClient>(client, Authenticate);
				// Authenticated and ready for API calls...
				
				// EITHER Calendar API calls (tested):
				CalendarService cal = new CalendarService(auth);
				EventsResource.ListRequest listrequest = cal.Events.List(this.primaryCal);
				Google.Apis.Calendar.v3.Data.Events events = listrequest.Fetch();
				// iterate the events and show them here.
				// OR Plus API calls (not tested) - copied from OP's code:
				var plus = new PlusService(auth);
				plus.Key = "BLAH";	// don't know what this line does.
				var me = plus.People.Get("me").Fetch();
				Console.WriteLine(me.DisplayName);
				
				// OR some other API calls...
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error while communicating with Google servers. Try again(?). The error was:\r\n" + ex.Message + "\r\n\r\nInner exception:\r\n" + ex.InnerException.Message);
			}
		}
		private IAuthorizationState Authenticate(NativeApplicationClient client)
		{
			IAuthorizationState state = new AuthorizationState(new string[] { }) { RefreshToken = this.refreshToken };
			
			// IMPORTANT - does not work without:
			client.ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(this.clientSecret);
			
			client.RefreshAuthorization(state);
			return state;
		}
	}
