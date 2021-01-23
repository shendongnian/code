    if (Contract
        .NullSafe(c => c.Parties)
        .NullSafe(p => p.Client)
        .NullSafe(c => c.Address) != null)
    {
        // do something with the adress
        Console.Writeline(Contract.Parties.Client.Adress.Street);
    }
