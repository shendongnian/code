    var dictUnmatchedAlphas = myAlphaItems.ToDictionary(a => a.Id);
    var myCorrelatedItems = new List<ABItem>();
    var myUnmatchedBravos = new List<Bravo>();
    foreach (Bravo b in myBravoItems)
    {
        var id = b.Id;
        if (dictUnmatchedAlphas.ContainsKey(id))
        {
            var a = dictUnmatchedAlphas[id];
            dictUnmatchedAlphas.Remove(id); //to get just the unmatched alphas
            myCorrelatedItems.Add(new ABItem { a = a, b = b});
        }
        else
        {
            myUnmatchedBravos.Add(b);
        }
    }
