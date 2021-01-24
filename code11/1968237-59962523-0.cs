class Card
{
    public string CardType { get; set; }
    public string Name { get; set; }
    public int AddressIndex { get; set; }
    public List<CardValues> Values { get; set; } // I don't know a good name for this
}
class CardValues
{
    public int Entry { get; set; }
    public int AdditionalParameters { get; set; }
}
Now you can adress them like this: `var values = card.CardValues[5];`. Note that this will throw an exception if there are less than six items in your list.
To add new values into this list, you can either just call `card.CardValues.Add(new CardValues { Entry = 1, AdditionalParameters = 5 });`, which will insert these values at the end of the list or call [`List.Insert`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.insert?view=netframework-4.8) to put them in a specific place.
