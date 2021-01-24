    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int RankId { get; set; }
        public Rank Rank { get; set; }
    }
    public class Rank
    {
        public int Id { get; set; }
        public string Something { get; set; }
    }
    public class Repo
    {
        public void Save(Player player)
        {
            // .. open connection
            player.RankId = connection.ExecuteScalar<int>("insert into Rank (Something) values (@Something)", player.Rank);
            player.Id = connection.ExecuteScalar<int>("insert into Player (Username, RankId) values (@Username, @RankId", player);
        }
    }
