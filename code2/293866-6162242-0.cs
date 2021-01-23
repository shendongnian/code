    private static string GetAlcoholStatuses(Enums.Enums.AlcoholStatus? alcoholStatus)
    {
        if (alcoholStatus == null)
            return string.Empty;
        Enums.Enums.AlcoholStatus alcoholStatusValue = alcoholStatus.Value;
        string alcoholStatuses = string.Empty;
        if (alcoholStatusValue.HasFlag(Enums.Enums.AlcoholStatus.Drinker))
        {
            alcoholStatuses = string.Format("{0}{1}{2}", alcoholStatuses, (int)Enums.Enums.AlcoholStatus.Drinker, ",");
        }
        if (alcoholStatusValue.HasFlag(Enums.Enums.AlcoholStatus.NonDrinker))
        {
            alcoholStatuses = string.Format("{0}{1}{2}", alcoholStatuses, (int)Enums.Enums.AlcoholStatus.NonDrinker, ",");
        }
        if (alcoholStatusValue.HasFlag(Enums.Enums.AlcoholStatus.NotRecorded))
        {
            alcoholStatuses = string.Format("{0}{1}{2}", alcoholStatuses, (int)Enums.Enums.AlcoholStatus.NotRecorded, ",");
        }
        return alcoholStatuses;
    }
