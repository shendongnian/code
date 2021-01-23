    string MyFunction (string k, string l)
    {
        Contract.Requires(!string.IsNullOrWhiteSpace(k));
        Contract.Requires(!string.IsNullOrWhiteSpace(l));
        Contract.Ensures(!string.IsNull(Contract.Return<string>()));
             :
    }
