    class MethodPosAware : IPositionAware<MethodPosAware>
	{
		public MethodPosAware(string methodName, IEnumerable<Expression> parameters)
		{
			Value = methodName;
			Params = parameters;
		}
		public MethodPosAware SetPos(Position startPos, int length)
		{
			Pos = startPos;
			Length = length;
			return this;
		}
		public Position Pos { get; set; }
		public int Length { get; set; }
		public string Value { get; set; }
		public IEnumerable<Expression> Params { get; set; }
	}
