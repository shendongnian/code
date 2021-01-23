    [ServiceContract]
    public class ZombieService
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "KnownZombies")]
        public Zombie GetZombie()
        {
           return new Zombie() { Name = "Mohammad Azam"};
        }
    }
    public class Zombie
    {
        public string Name { get; set; }
    }
