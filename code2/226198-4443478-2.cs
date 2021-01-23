    ILookup<int, int> selectedProgramTierCombo =
    (
      from priceProgram in doc.CommitmentProgram.PricingPrograms
      from progTier in priceProgram.Tiers
      where doc.TierID.Any(mainTierID => mainTierID == progTier.TierID)
      select new
      {
        ProgramID = priceProgram.ProgramID,
        TierID = progTier.TierID
      }
    ).ToLookup(x => x.ProgramID, x => x.TierID);
