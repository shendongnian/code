    Dictionary<int, int> selectedProgramTierCombo =
        (from mainTierID in doc.TierID
         from priceProgram in doc.CommitmentProgram.PricingPrograms
         join progTier in priceProgram.Tiers on mainTierID equals progTier.TierID
         select new { priceProgram.ProgramID, progTier.TierID })
        .ToDictionary(x => x.ProgramID, x => x.TierID);
