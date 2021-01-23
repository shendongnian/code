    var result = new List<AuthenticationEssay>();
    for (var i = 0; i < (essays.Count() - 1); i++)
    {
        if (essays[i + 1] != null)
            if (essays[i + 1].Date - essays[i].Date < new TimeSpan(0, 0, 0, 20))
                result.Add(essays[i]);
    }
