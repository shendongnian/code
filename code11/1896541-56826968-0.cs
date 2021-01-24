    using System.Linq;
    if (messageToSend.Split(' ').Any(word => purgeWords.Contains(word.ToLower())))
    {
        isBadWord = true;
    }
