    public class Player 
    {
    public string username;
    public double rating;
    public string title;
    }
    
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://lichess.org/");
    HttpResponseMessage response = client.GetAsync("player/top/200/bullet").Result;
    //Now ENSURE you get a 200 status code, only then proceed ahead with the process
    if (response.IsSuccessStatusCode)
    {
      Player player=new Player();
      var result = response.Content.ReadAsStringAsync().Result;
      player= JsonConvert.DeserializeObject<Player>(result);
     //Access your variables now
     string recievedUsername=player.username;
     double recievedRating=player.rating;
     string recievedTitle=player.title;
    }
