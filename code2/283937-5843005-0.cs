    public Text GetLocalizedText(Func<Text, bool> predicate, string language )
    {
        var temp = MyDb.Texts.Where(predicate);
        return temp.SingleOrDefault(x => x.Language == language)
            ?? temp.Single(x => x.Language == "English");
    }
    var caption = GetLocalizedText(x => x.TextId == 1, "Danish")
