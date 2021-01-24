    IEnumerable<IMyInterface> myTerms = terms.Select(term => new AgentTerm
        {
             TermResult = term,
        })
        .Cast<IMyInterface>();
    IEnumerable<IMyInterface> myHosps = hosps.Select(hosp => new MyHosp
        {
            Hosp = hosp,
        })
        .Cast<IMyInterface>();
    var result = myTerms.Concat(myHosps);
