    public static class TextExtensions
        {
            
            IEnumerable<Text> ByTextId(this IEnumerable<Text> qry, int textId)
            {
                return qry.Where(t => t.TextId == textId);
            }
    
            IEnumerable<Text> ByLanguage(this IEnumerable<Text> qry, string language)
            {
                return qry.Where(t => t.Language == language);
            }
        }
