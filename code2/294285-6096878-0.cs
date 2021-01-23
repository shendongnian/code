    private static IQueryable<Persoon> Filter(IQueryable<Persoon> qF, IDictionary<string, string> filter)
    {
        IQueryable<Persoon> temp;
        temp = qF;
        foreach (var key in filter)
        {
            var currentKeyValue = key.Value;
            if (key.Key == "naam")
            {
                temp = temp.Where(f => f.Naam == currentKeyValue);
            }
            else if (key.Key == "leeftijd")
            {
                temp = temp.Where(af => af.Leeftijd != null && af.Leeftijd.AantalJaarOud == Int32.Parse(currentKeyValue));
            }
        }
        return temp;
    
    }
