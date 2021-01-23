    string authToken, txToken, query;
            string strResponse;
            authToken = ConfigurationManager.AppSettings["PDTToken"];
            //read in txn token from querystring
            txToken = Request.QueryString.Get("tx");
            query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);
            // Create the request back
            string url = ConfigurationManager.AppSettings["PayPalUrl"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;
            // Write the request back IPN strings
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(query);
            stOut.Close();
            // Do the request to PayPal and get the response
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();
            stIn.Close();            
            // If response was SUCCESS, parse response string and output details
            if (strResponse.StartsWith("SUCCESS"))
            {
               
            }
