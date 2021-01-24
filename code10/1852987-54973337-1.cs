    driverDayLogModel driverDayLog = new driverDayLogModel
    {
        driverId = Convert.ToInt32(txtId.Text),
        dayStartTime = DateTime.Now,
    };
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://127.0.0.1:54314/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // simply put the object as the second parameter instead of a Json string
        var response = client.PostAsJsonAsync("api/driverdaylogs", driverDayLog).Result;
        if (response.IsSuccessStatusCode)
        {
            // Some Stuff
        }
        else
        {
            MessageBox.Show("Error Code" +
            response.StatusCode + " : Message - " + response.ReasonPhrase);
        }
    }
