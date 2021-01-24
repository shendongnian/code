    class Player
    {
        int Health {get; set;}
        int Balance {get; set;}
    }
    
    static void Main(string[] args )
    {
        Player player = new Player();
        player.Balance = 0;
        player.Health = 50;
        Battle(player);
    }
    
    static void Battle(Player player);
    {
        player.Balance = player.Balance + 30;
        player.Health = player.Health - 5;
    }
