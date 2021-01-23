    using System.Text.RegularExpressions;
    private string formatTweetText(string tweet)
    {
        string newText = " " + Regex.Replace(tweet, "/http:\/\/\S+/g", "Replacement String") + " ";
        return newText.SubString(1, (newText.Length - 2));
    }
    
