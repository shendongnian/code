    async Task<Player> getPlayerAsync(string path)
    {
        Player player= null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            player = await response.Content.ReadAsAsync<Player>();
        }
        return player;
    }
    getPlayerAsync("https://lichess.org/player/top/200/bullet");
