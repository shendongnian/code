csharp
private class Player
{
    public int GoldBalance = 0;
}
private class Mine
{
    public int GoldAvailable = 10;
    public void Collect(Player player)
    {
        if (GoldAvailable <= 0)
            return;
        player.GoldBalance += GoldAvailable;
        GoldAvailable = 0;
    }
}
