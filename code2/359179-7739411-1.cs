    public class Example : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            //put user code to initialise page here
            var client = new System.Net.WebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
		
            var data = System.Text.Encoding.ASCII.GetBytes(
                "clientid=[clientid]&password=[password]&oid=[orderid]&" + 
                "chargetype=PreAuth&currencycode=826&total=[total]");
			
            var response = client.UploadData(
                "https://secure2.epdq.co.uk/cgi-bin/CcxBarclaysEpdqEncTool.e", 
                "POST", data);
			
            Session["Response"] = System.Text.Encoding.ASCII.GetString(response);
        }
    }
