    public class EnvironmentConditions
    {
        ...
        public EnvironmentConditions(EnvironmentConditionsInput input)
        {
            ConditionType = input.ConditionType;
            CoolingSetPointOccupied = input.CoolingSetPointOccupied ?? 0;
            CoolingSetPointUnOccupied = input.CoolingSetPointUnOccupied ?? 0;
            HeatingSetPointOccupied = input.HeatingSetPointOccupied ?? 0;
            RelativeHumidityMax = input.RelativeHumidityMax ?? 0;
            RelativeHumidityMin = input.RelativeHumidityMin ?? 0;
            // some new property
        }
    }
    // new EnvironmentConditions(spaceTypeInput.EnvironmentConditionsInput);
