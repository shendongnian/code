    public static TheModelYouWant ToTheModelYouWant(IEnumerable<TheModelYouHave> source)
    {
        var grouped = source.GroupBy(src => src.PaxsReserva, src => src);
        var result = new TheModelYouWant();
        foreach(var group in grouped)
            result.ModelsGroupedByPaxsReserva.Add(group.Key, group);
        return result;
    }
