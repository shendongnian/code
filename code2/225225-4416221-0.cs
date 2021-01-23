    private static void ConvertStringToArray(string p)
    {
    string[] CardsToBeSortedArray = p.Split(',');
    int[] IntCard = Array.ConvertAll<string, int>(CardsToBeSortedArray, delegate(string
    card)
    {
    int result;
    int32.TryParse(card, out result);
    return result;
    });
    }
