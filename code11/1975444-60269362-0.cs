 public async Task<List<Player>>GetPlayersByNameAsync(string name)
    {
        List<Player> result = await _database.QueryAsync<Player>("SELECT * from Player where 
             PlayerName LIKE " + name);
        return result;
    }
to
 public async Task<List<Player>>GetPlayersByNameAsync(string name)
    {
        List<Player> result = await _database.QueryAsync<Player>("SELECT * from Player where 
             PlayerName LIKE '%" + name+ "%');
        return result;
    }
But you should use SqlParameter instead of variables directly. To get better performance and avoid sql-injection - read here: https://stackoverflow.com/questions/4329953/c-sharp-sqlite-parameterized-select-using-like/32297560
