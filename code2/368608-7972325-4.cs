    [WebMethod]
    public string Concat(List<string> arr)
    {
        string result = "";
        for (int i = 0; i < arr.Count; i++)
        {
            result += arr[i];
        }
        return result;
    }
