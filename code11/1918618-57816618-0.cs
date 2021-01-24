           HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sitename.azurewebsites.net");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
            //retrieve the ssl cert and assign it to an X509Certificate object
            X509Certificate cert = request.ServicePoint.Certificate;
            //convert the X509Certificate to an X509Certificate2 object by passing it into the constructor
            X509Certificate2 cert2 = new X509Certificate2(cert);
            //show expiratin date
            Console.WriteLine("expiratin date: "+cert2.GetExpirationDateString());
