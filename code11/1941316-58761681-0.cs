cs
public static User GetUser(ulong discordId)
{
    using var con = new SQLiteConnection(Globals.DbConnectionString);
    var user = con.QueryFirstOrDefault<dynamic>($"SELECT * FROM {DbTable} WHERE discord_id = @discordId", new
    {
        discordId
    });
    if (user == null) return null;
    return new User
    {
        DiscordId = (ulong)user.discord_id,
        RegistrationTimestamp = (long)user.registration_timestamp,
        Email = (string)user.email,
        Balance = (double)user.balance,
        Profit = new Profit
        {
            Net = (double)user.net_profit,
            ATH = (double)user.ath_profit,
            ATL = (double)user.atl_profit
        }
    };
}
