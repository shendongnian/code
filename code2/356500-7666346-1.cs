    public static string AddImgTags(string input)
    {
       string pattern = @"\$([^\$]*)\$";
       foreach (Match match in Regex.Matches(input, pattern))
       {
          input = input.Replace(match.Value, 
             string.Format("<img src=\"http://chart.googleapis.com/chart?cht=tx&chl={0}\" alt=\"{0}\" />", 
             HttpUtility.UrlEncode(match.Value)));
       }
       return input;
    }
