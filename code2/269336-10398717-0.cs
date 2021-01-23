	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	 
	using System.Configuration;
	using Twilio;
	 
	namespace TwilioSMSHowTo
	{
		public partial class _default : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
			}
	 
			protected void SendMessage_OnClick(object sender, EventArgs e)
			{
				string ACCOUNT_SID = ConfigurationManager.AppSettings["ACCOUNT_SID"];
				string AUTH_TOKEN = ConfigurationManager.AppSettings["AUTH_TOKEN"];
	 
				TwilioRestClient client = new TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN);
	 
				client.SendSmsMessage("(502) 276-8990", ToNumber.Text, Message.Text);
			}
		}
	}
