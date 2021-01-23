    Dictionary<int, int> selectedProgramTierCombo =
    (
      from priceProgram in doc.CommitmentProgram.PricingPrograms
      let tierId =
      (
        from progTier in priceProgram.Tiers
        where doc.TierID.Any(mainTierID => mainTierID == progTier.TierID)
        select progTier.TierID
      ).Single()
      select new
      {
        ProgramID = priceProgram.ProgramID,
        TierID = tierID
      }
    ).ToDictionary(x => x.ProgramID, x => x.TierID);
