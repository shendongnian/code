    public void sendsms(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" + yourmobilenumber + "&pwd=" + yourpassword + "&msg=" + body.Text + "&phone=" + recipientNo.Text + "&provider=way2sms");
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
    }
