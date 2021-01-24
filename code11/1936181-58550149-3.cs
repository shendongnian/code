    .Select(pt => new PolicyViewModel
    {
        PolicyNumber = pt.Policy_Number,
        Date = pt.Date,
        PrimerNumber = pt.Policy_Primer.Number,
        // ...
    })
