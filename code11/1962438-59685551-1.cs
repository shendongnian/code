    foreach (var client in lKlijent)
    {
        PoliceOsiguranja policy = lPoliceOsiguranja.Where(x => x.OIB == client.OIB).FirstOrDefault();
        table.AddRow(policy.property1, policy.property2, client.property1, client.property2) ;
    }
Depending on how your data look, you might have to run through multiple foreach loops. If you have one policy per client, then above works. If you have one client per policy, you can flip the loop and use Policies as the loop and look up client based on the policy you are iterating through.
If you have **multiple clients** for each policy, then you are better off using a separate foreach loop as well.
    foreach (var policy in lPoliceOsiguranja)
        foreach (var client in lKlijent.Where(x => x.OID == policy.OID))
            table.AddRow(policy.property1, policy.property2, client.property1, client.property2);
        
