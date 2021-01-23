    var dict = (from mainTierID in doc.TierID
                join f in
                    (from priceProgram in doc.CommitmentProgram.PricingPrograms
                        from progTier in priceProgram.Tiers
                        select new { priceProgram.ProgramID, progTier.TierID })
                    on mainTierID equals f.TierID
                select f).ToDictionary(f => f.ProgramID, f => f.TierID);
    var dict2 = (from priceProgram in doc.CommitmentProgram.PricingPrograms
                    from progTier in priceProgram.Tiers
                    join mainTierID in doc.TierID on progTier.TierID equals mainTierID
                    select new { priceProgram.ProgramID, progTier.TierID })
                .ToDictionary(x => x.ProgramID, x => x.TierID);
