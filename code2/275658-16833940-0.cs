    private void button1_Click(object sender, EventArgs e)
        {
        
            var url = "servicsURL";
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);
                NetworkCredential networkCredential = new NetworkCredential("UserName", "password","domain");
                // Associate the 'NetworkCredential' object with the 'WebRequest' object.
                myRequest.Credentials = networkCredential;
                var response = (HttpWebResponse)myRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //  it's at least in some way responsive
                    //  but may be internally broken
                    //  as you could find out if you called one of the methods for real
                    MessageBox.Show(string.Format("{0} Available", url));
                }
                else
                {
                    //  well, at least it returned...
                    MessageBox.Show(string.Format("{0} Returned, but with status: {1}", url, response.StatusDescription));
                }
            }
            catch (Exception ex)
            {
                //  not available at all, for some reason
                MessageBox.Show(string.Format("{0} unavailable: {1}", url, ex.Message));
            }
        }
