    private void button4_Click(object sender, EventArgs e)
            {
                try
                {
                    var uriString = "http://192.168.0.1/cgi-bin/webcm";
                    WebClient myWebClient = new WebClient();
                    NameValueCollection myNameValueCollection = new NameValueCollection();
                    myNameValueCollection.Add("getpage", "../html/status_hide.html");
                    myNameValueCollection.Add("var:opt", "0");
                    myNameValueCollection.Add("logic:command/kill_ppp", "");
                    myNameValueCollection.Add("encaps0:pppoa:command/stop", "1");
                    byte[] responseArray = myWebClient.UploadValues(uriString, myNameValueCollection);
                    log("Failed to update mail date creation, function UpdateMailDateCreation. MySQL error:" + Encoding.ASCII.GetString(responseArray));
                }
                catch (Exception ex)
                {
                    log(ex.ToString());
                }
            }
