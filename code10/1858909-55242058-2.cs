    [Headers("Content-Type: application/json")]
    public interface ISteamService
    {
        [Get("/IPlayerService/GetOwnedGames/v1/?key=XXXXC&include_appinfo=1&steamid=XXXX")]
        Task<GamesList> GetGames();
    }
