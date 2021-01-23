            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Login");
            XmlElement id = doc.CreateElement("id");
            id.SetAttribute("userName", usernameTxb.Text);
            id.SetAttribute("passWord", passwordTxb.Text);
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = nameTxb.Text;
            XmlElement age = doc.CreateElement("Age");
            age.InnerText = ageTxb.Text;
            XmlElement Country = doc.CreateElement("Country");
            Country.InnerText = countryTxb.Text;
            id.AppendChild(name);
            id.AppendChild(age);
            id.AppendChild(Country);
            root.AppendChild(id);
            doc.AppendChild(root);
            //Request needs to be in the format: ftp://example.com/path/file.xml or ftp://example.com/file.xml
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://users.skynet.be/" + usernameTxb.Text + ".xml");
            //Specify that we're uploading a file
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UsePassive = false;
            request.Credentials = new NetworkCredential("fa490002", "password");
            //Get raw access to the request stream
            using (Stream s = request.GetRequestStream())
            {
                //Save the XML doc to it
                doc.Save(s);
            }
            //Push the request to the server and await its response
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //We should get a 226 status code back from the server if everything worked out ok
            if (response.StatusCode == FtpStatusCode.ClosingData){
                MessageBox.Show("Created SuccesFully!");
            }else{
                MessageBox.Show("Error uploading file:" + response.StatusDescription);
            }
            response.Close();
           
            this.Close();
