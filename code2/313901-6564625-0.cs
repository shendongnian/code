    public string return_Result(String[,] RssData, int marketId)
    {
        string result = "";
        foreach (var item in RssData)
        {
            if (item.ToString() == marketId.ToString())
            {
                result = item.ToString();
            }
        }
        return result;
    }
