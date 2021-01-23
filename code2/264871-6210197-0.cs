            string p1 = "access_token=" + Server.UrlEncode(_token);
            string p2  = "&batch=" + Server.UrlEncode(" [ { \"method\": \"get\", \"relative_url\": \"me\" }, { \"method\": \"get\", \"relative_url\": \"me/friends\" } ]");
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/");
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                byte[] bytedata = Encoding.UTF8.GetBytes(p1 + p2);
                httpRequest.ContentLength = bytedata.Length;
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(bytedata, 0, bytedata.Length);
                requestStream.Close();
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                string APIData = reader.ReadToEnd();
                Response.Write(APIData);
            }
            catch (Exception ex)
            { Response.Write(ex.Message.ToString() + "<br>"); }
           // JObject MyApiData = JObject.Parse(APIData);
        }
