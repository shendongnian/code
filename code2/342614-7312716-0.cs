    public void GetData()
    {
        var client = new WebClient();
        client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_GetDataCompleted);
        client.OpenReadAsync(new Uri(_address));
    }
    
    void client_GetDataCompleted(object sender, OpenReadCompletedEventArgs e)
    {
      var serializer = new DataContractJsonSerializer(typeof(JSONDataObject),null);
      var data = serializer.ReadObject(e.Result) as JSONDataObject;
      
      //do what you need with the data
    }
    [DataContract(Name = "JSONDataObject")]
    public class JSONDataObject
    {
        [DataMember(Name = "id", Order = 0)]
        public int Id 
        {
            get;set; 
        }
        [DataMember(Name = "name", Order = 1, EmitDefaultValue = false)]
        public string Name 
        {
            get;set; 
        }
    }
