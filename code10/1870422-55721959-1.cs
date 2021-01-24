    url = url + "/" + MembershipNumber;
    var client = new RestClient(url);
    var request = new RestRequest(Method.POST);
    request.AddHeader("Authorization", "Bearer " + Token);
    // This how you assign your values for the RootObject class
    RootObject MyObject = RootObject();
    MyObject.LicenceNumber  = LicenceNumber;
    MyObject.CardNumber = CardNumber;
    // then for the activities class you can do the following
    MyObject.Activities = new List<Activity>();
    MyObject.Activities.Add(new Activity(){StartTime = "2019-04-14 09:00:00", Duration = "480",ActivityType = "Rest"});
    string jsonString = JsonConvert.SerializeObject(MyObject);
    request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
    IRestResponse response = client.Execute(request);
