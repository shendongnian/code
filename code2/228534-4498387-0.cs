class Player
{
    public Player(int n)
    {
        Cards = new List<CardType>(n);
    }
    public IList<CardType> Cards { get; private set; }
}
enum CardType
{
    Diamond,
    Club,
    Spade,
    Heart
}
