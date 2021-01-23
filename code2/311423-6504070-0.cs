    public static string UrlDoubleEncode(string text)
    {
        if (text == null)
            return null;
        StringBuilder sb = new StringBuilder();
        foreach (int i in text)
        {
            sb.Append('&');
            sb.Append('#');
            sb.Append(i);
            sb.Append(';');
        }
        return HttpUtility.UrlEncode(sb.ToString());
    }
