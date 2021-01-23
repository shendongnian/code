    public SprinklerLineModel()
    {
        NearCrossMainDimension = new PipeDimensionModel();
        FarCrossMainDimension = new PipeDimensionModel();
        Init();
    }
    public SprinklerLineModel(SprinklerLineModel sprinklerLineModel)
    {
        this.EstimatedFlow = sprinklerLineModel.EstimatedFlow;
        this.EstimatedPressure = sprinklerLineModel.EstimatedPressure;
        this.NearCrossMainDimension = new PipeDimensionModel(sprinklerLineModel.NearCrossMainDimension);
        this.FarCrossMainDimension = new PipeDimensionModel(sprinklerLineModel.FarCrossMainDimension);
        this.BranchLineDiameter = sprinklerLineModel.BranchLineDiameter;
        this.LeadLinePipeFittingLength = sprinklerLineModel.LeadLinePipeFittingLength;
        this.ExbPipeFittingLength = sprinklerLineModel.ExbPipeFittingLength;
        this.IsDirty = sprinklerLineModel.IsDirty;
        Init();
    }
    void Init()
    {
        this.AddValidationRule(Rule.CreateRule(() => BranchLineDiameter, RuleMessage.GREATER_THAN_ZERO, () => BranchLineDiameter > 0));
    }
