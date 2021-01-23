    string json = @"[
    
        {
          "newNickInfo": "2775040", 
          "idUser": "2775040",
          "nick":"minci88",
          "sefNick":"minci88",
          "sex":2,
          "photon":"http:\/\/213.215.107.125\/fotky\/277\/50\/n_2775040.jpg?v=4",
          "photos":"http:\/\/213.215.107.125\/fotky\/277\/50\/s_2775040.jpg?v=4",
          "logged":false,
          "idChat":0,
          "roomName":"",
          "updated":"1289670130"
         }
    ]";
    
    
    
    public class User 
    {
    [JsonProperty] 
    public string idUser{get;set;}
    [JsonProperty] 
    public string nick{get;set;}
    [JsonProperty] 
    public string sefNick{get;set;}
    [JsonProperty] 
    public string sex{get;set;}
    [JsonProperty] 
    public string photon{get;set;}
    [JsonProperty] 
    public string photos{get;set;}
    [JsonProperty] 
    public bool logged{get;set;}
    [JsonProperty] 
    public int idChat{get;set;}
    [JsonProperty] 
    public string roomName{get;set;}
    [JsonProperty] 
    public string updated{get;set;} 
    }
    
    
    List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
    
    User u1 = users[0];
     
    Console.WriteLine(u1.nick);
