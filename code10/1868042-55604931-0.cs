        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = httpClient.GetAsync("https://api.reckon.com/R1/cashbooks").Result;
            string responseText = response.Content.ReadAsStringAsync().Result;`enter code here`
            JArray parsedArray = JArray.Parse(responseText);
            DataTable dtSource = new DataTable();
	dtSource.Columns.AddRange(new DataColumn[]{new DataColumn("BookID"),new DataColumn("BookName")});
            foreach (JObject parsedObject in parsedArray.Children<JObject>())
            {
    string BookID,BookName;
                foreach (var parsedProperty in parsedObject.Properties())
                {
    if (parsedProperty.Name == "BookId")
                    {
    BookID= parsedProperty.Value;
                    }
    else if (parsedProperty.Name == "BookName")
                    {
    BookName= parsedProperty.Value;
                    }
                }
    dtSource.Rows.Add(BookID,BookName);
            }
        }
    comboBox2.DataSource = dtSource;
    comboBox2.DisplayMember = "BookName";
    comboBox2.ValueMember = "BookID";
