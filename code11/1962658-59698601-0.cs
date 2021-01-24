	var environmentCondition = new EnvironmentConditions
	{
		ConditionType = spaceTypeInput.EnvironmentConditionsInput.ConditionType,
		CoolingSetPointOccupied = spaceTypeInput.EnvironmentConditionsInput.CoolingSetPointOccupied ?? 0,
		CoolingSetPointUnOccupied = spaceTypeInput.EnvironmentConditionsInput.CoolingSetPointUnOccupied ?? 0,
		HeatingSetPointOccupied = spaceTypeInput.EnvironmentConditionsInput.HeatingSetPointOccupied ?? 0,
		RelativeHumidityMax = spaceTypeInput.EnvironmentConditionsInput.RelativeHumidityMax ?? 0,
		RelativeHumidityMin = spaceTypeInput.EnvironmentConditionsInput.RelativeHumidityMin ?? 0
	};
