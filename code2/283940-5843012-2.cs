    public static class TextExtensions
        {
            [System.Runtime.CompilerServices.Extension]
            public static IEnumerable<Text> ByTextId(this IEnumerable<Text> qry, int textId)
            {
                return qry.Where(t => t.TextId == textId);
            }
    
            [System.Runtime.CompilerServices.Extension]            
            public static IEnumerable<Text> ByLanguage(this IEnumerable<Text> qry, string language)
            {
                return qry.Where(t => t.Language == language);
            }
        }
