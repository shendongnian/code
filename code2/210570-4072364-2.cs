    public Enum Outcome
    {
        Ball,
        Strike,
        Homerun
    }
    var weights = new Dictionary<Outcome, int>();
    weights.Add(Ball, 40);
    weights.Add(Strike, 55);
    weights.Add(Homerun, 5);
    Outcome randomOutcome = ChooseRandomOutcome(weights);
    // it should be a homerun 5% of the time.
