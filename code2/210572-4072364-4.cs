    public Enum PitchOutcome
    {
        Ball,
        Strike,
        Hit
    }
    public Enum HitOutcome
    {
        PopFly,
        HomeRun,
        Single,
    }
    var weights = new Dictionary<PitchOutcome, int>();
    weights.Add(PitchOutcome.Ball, 40);
    weights.Add(PitchOutcome.Strike, 30);
    weights.Add(PitchOutcome.Hit, 30);
    PitchOutcome randomOutcome = ChooseRandomOutcome(weights);
    // it should be a Hit 30% of the time.
    
    if (randomOutcome == PitchOutcome.Hit)
    {
        var hitWeights = new Dictionary<HitOutcome, int>();
        hitWeights.Add(HitOutcome.PopFly, 50);
        hitWeights.Add(HitOutcome.HomeRun, 5);
        hitWeights.Add(HitOutcome.Single, 45);
        HitOutcome hitResult = ChooseRandomOutcome(hitWeights);
    }
