    public static List<PhraseSource> GetPhraseSources(List<CategorySource> categorySources)
    {
        return App.DB.db1.Table<PhraseSource>()
            .Select(item =>
            {
                new PhraseSource
                {
                    OneHash = Math.Abs(item.Id.GetHashCode() % 10),
                    TwoHash = Math.Abs(item.Id.GetHashCode() % 20),
                    ThreeHash = Math.Abs(item.Id.GetHashCode() % 50)
                }
            })
            .ToList();
    }
