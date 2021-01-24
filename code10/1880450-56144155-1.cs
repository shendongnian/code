    public float Price
		{
			get
			{
				return returnValue;
			}
			set
			{
				if (value > 30)
				{
					returnValue = value - (value * 0.10f);
				}
				else
				{
					palautus = value;
				}
			}
		}
