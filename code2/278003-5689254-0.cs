    static IEnumerable<AuthenticationEssay> Filter(IEnumerable<AuthenticationEssay> list)
    {
        AuthenticationEssay last = null;
        AuthenticationEssay previous = null;
        foreach(var item in list)
        {
            if (last == null)
            {
                // Always return the first item
                yield return item;
            }
            else if ((item.Date - last.Date).TotalSeconds >= 20)
            {
               yield return item;
            }
            previous = last;
            last = item;
        }
        if (previous != null && last != null && (last.Date - previous.Date).TotalSeconds <= 20)
           yield return last;
    }
