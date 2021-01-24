    HttpClient http = new HttpClient();
    IDictionary<String, Int32> countrycounts = new Dictionary<String, Int32>();
    string url = "https://restcountries.eu/rest/v2/all/";
    HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
    string responseBody = response.Content.ReadAsStringAsync().Result;
    var countries = JsonConvert.DeserializeObject(responseBody);
    var details = JObject.Parse(countries.ToString());
    foreach (var obj in details){
    string countrynames = details["name"].ToString();
    if (countrycounts.ContainsKey(countrynames))
    {
    int count = countrycounts[countrynames];
    count++;
    countrycounts[countrynames] = count;
    comboBox1.Items.Add(countrynames);
    }
    else { comboBox1.Items.Add(countrynames); }
