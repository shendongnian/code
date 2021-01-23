	public enum ConditionType {Fair, LikeNew, Mint, New}
	public ConditionType Condition { get; set; }
	public bool IsNew
	{
		get { return Condition == ConditionType.New || Condition == ConditionType.Mint; }
	}
