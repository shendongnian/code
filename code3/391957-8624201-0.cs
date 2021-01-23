    IEnumerable enumerable = (IEnumerable)member.GetValue(this.TalentProfile);
    if (enumerable != null)
    {
        IEnumerator enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            object obj = enumerator.Current;
            // do something with obj
        }
    }
