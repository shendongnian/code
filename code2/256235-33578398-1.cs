protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var values = string.Format("Name={0}&Family={1}&Id={2}", NameToUpdateTextBox.Text, FamilyToUpdateTextBox.Text, IdToUpdateTextBox.Text);
            var bytes = Encoding.ASCII.GetBytes(values);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:51436/api/employees"));
            request.Method = "PUT";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            var response =  (HttpWebResponse) request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
                UpdateResponseLabel.Text = "Update completed";
            else
                UpdateResponseLabel.Text = "Error in update";
        }
