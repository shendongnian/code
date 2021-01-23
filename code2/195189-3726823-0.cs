    public string UrlCorrection (string text)
    {
        StringBuilder correctedText = new StringBuilder (text);
    
        return correctedText.Replace("ç", "c")
                            .Replace("ı", "i")
                            .Replace("ü", "u")
                            .Replace("ğ", "g")
                            .Replace("ö", "o")
                            .Replace("ş", "s")
                            .ToString ();
    }
