    RestResponse<ResultData> response = client.Execute<ResultData>(restRequest);
    ResultData data = response.Data;
    if (data != null)
    {
        // Now the Data property will be null, so we need to parse that badboy.
        JObject linqData = JObject.Parse(response.Content);
        var array = linqData["response"]["data"] as JArray;
        if (array != null)
        {
            data.Response.Data = 
                (from x in array
                select new MyPoco
                            {
                                SubjectKey = x[0].Value<string>(),
                                UUid = x[1].Value<string>(),
                                Name = x[2].Value<string>(),
                                Address = x[3].Value<string>(),
                                City = x[4].Value<string>(),
                                Territory = x[5].Value<string>(),
                                Postcode = x[6].Value<string>(),
                                Telephone = x[7].Value<string>(),
                                Category = x[9].Value<string>(),
                                Website = x[10].Value<string>(),
                                Email = x[11].Value<string>(),
                                Latitude = x[12].Value<float>(),
                                Longitude = x[13].Value<float>()
                            }).ToList();
        }
    }
