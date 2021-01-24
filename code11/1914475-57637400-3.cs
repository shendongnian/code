    public ICarDetails GetCarInfo(string car) {
        var client = new RestClient("http://xxx.xxxxxxx.com");
        var request = new RestRequest("/{car} ? access_key =xxxxxxxxx", Method.GET);
        var queryResult = client.Get<CarDetails>(request).Data;
        return queryResult;
    }
