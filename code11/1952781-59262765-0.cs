csharp
public async Task<bool> PickCard()
{
    // This is a switch *expression* instead of a switch *statement*.
    // Switch expressions were introduced in C# 8.
    bool result = Settings.Co switch
    {
        CO.Random => Random(),
        CO.FirstToLast => ArrangeCardOrder(true),
        CO.LastToFirst => ArrangeCardOrder(false),
        // Adjust for whatever you want to do
        _ => throw new InvalidOperationException("Invalid setting")
    }
    if (result)
    {
        await ShowCard();
    }
    return result;
}
