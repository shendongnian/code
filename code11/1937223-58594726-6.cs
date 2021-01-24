    public static List<PhraseSource> GetPhraseSources(List<CategorySource> categorySources)
    {
        List<PhraseSource> phraseSources = App.DB.db1.Table<PhraseSource>().ToList();
        phraseSources.ForEach(item => {
                item.OneHash = Math.Abs(item.Id.GetHashCode() % 10);
                item.TwoHash = Math.Abs(item.Id.GetHashCode() % 20);
                item.ThreeHash = Math.Abs(item.Id.GetHashCode() % 50);
            });
        return phraseSources;
    }
