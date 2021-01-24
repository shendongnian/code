    Public static string PrintName(string StrValue)//pass here - o'riley
            {
                if (!string.IsNullOrEmpty(StrValue))
                {
                    return Regex.Replace(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(StrValue.ToLower()),
                     "['-](?:.)", m => m.Value.ToUpperInvariant());
                }
                else
                {
                    return "Something meaningful message";
                }
            } 
