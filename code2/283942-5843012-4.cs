    [System.Runtime.CompilerServices.Extension]
    public static IEnumerable<Text> GetValueOrDefault(this IEnumerable<Text> qry, int textId, string language)
    {
        return qry.DefaultIfEmpty(qry.ByTextId(textId).ByLanguage(LanguageValues.English).Single()).ByTextId(textId).ByLanguage(language);
    }
