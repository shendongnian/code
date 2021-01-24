    Dictionary<string, Device> devices = new Dictionary<string, Device>();
    string json = "{\"192.168.0.12\": {\"Name\":\"12\",\"Mode\":\"STOP\"},\"192.168.0.13\": {\"Name\":\"13\",\"Mode\":\"STOP\"}}";
    var result = JsonConvert.DeserializeObject<dynamic>(json);
    foreach (var item in result)
    {
             
             var name = item.Name;
             evices.Add(item.Name.ToString(), new Device {Name = item.Value.Name.ToString(), Mode = item.Value.Mode.ToString()});
             
     }
