            System.Net.WebRequest r = System.Net.WebRequest.Create("http://www.google.com");
            r.Timeout = 3000;
            System.Net.WebProxy proxy = new System.Net.WebProxy("<proxy address>");
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
            credentials.Domain = "<domain>";
            credentials.UserName = "<login>";
            credentials.Password = "<pass>";
            proxy.Credentials = credentials;
            r.Proxy = proxy;
            try
            {
                System.Net.WebResponse rsp = r.GetResponse();
            }
            catch (Exception)
            {
                MessageBox.Show("Is not avaliable");
                return;
            }
            MessageBox.Show("Avaliable!");
