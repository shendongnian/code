    Dictionary<int, int> selectedProgramTierCombo =
        (from mainTierID in doc.TierID
         from priceProgram in doc.CommitmentProgram.PricingPrograms
         from progTier in priceProgram.Tiers
         where mainTierID == progTier.TierID
         select new { priceProgram.ProgramID, progTier.TierID })
        .ToDictionary(x => x.ProgramID, x => x.TierID);
