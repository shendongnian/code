    //with Message Contract
    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client(ServiceReference1.Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
    var request = new ServiceReference1.GetDataRequest(34);
    var response1 = client.GetDataAsync(request);
    MyLabel.Content = response1.Result.GetDataResult;
    
    //Without checked MessageContract
    ServiceReference2.Service1Client client1 = new ServiceReference2.Service1Client(ServiceReference2.Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
    var response2 = client1.GetDataAsync(34);
    MyLabel.Content += " " + response2.Result;
