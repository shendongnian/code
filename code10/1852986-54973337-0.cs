    driverDayLogModel driverDayLog = new driverDayLogModel
    {
        driverId = Convert.ToInt32(txtId.Text),
        dayStartTime = DateTime.Now,
    };
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://127.0.0.1:54314/");
        var response = client.PostAsync<driverDayLogModel>("api/driverdaylogs", driverDayLog).Result;
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
