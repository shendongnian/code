    public SprinklerLineModel()
        : this(null)
    {
    }
    /// <summary> 
    /// Copy Constructor 
    /// </summary> 
    /// <param name="sprinklerLineModel">Original copy of sprinklerLineModel</param> 
    public SprinklerLineModel(SprinklerLineModel sprinklerLineModel)
    {
        this.EstimatedFlow = sprinklerLineModel.EstimatedFlow;
        this.EstimatedPressure = sprinklerLineModel.EstimatedPressure;
        if (sprinklerLineModel != null)
        {
            this.NearCrossMainDimension = new PipeDimensionModel(sprinklerLineModel.NearCrossMainDimension);
            this.FarCrossMainDimension = new PipeDimensionModel(sprinklerLineModel.FarCrossMainDimension);
        }
        else
        {
            NearCrossMainDimension = new PipeDimensionModel();
            FarCrossMainDimension = new PipeDimensionModel();
        }
        this.BranchLineDiameter = sprinklerLineModel.BranchLineDiameter;
        this.LeadLinePipeFittingLength = sprinklerLineModel.LeadLinePipeFittingLength;
        this.ExbPipeFittingLength = sprinklerLineModel.ExbPipeFittingLength;
        this.IsDirty = sprinklerLineModel.IsDirty;
        this.AddValidationRule(Rule.CreateRule(() => BranchLineDiameter, RuleMessage.GREATER_THAN_ZERO, () => BranchLineDiameter > 0));
    }
