    var deserialized = new PointProperty
    {
        DataPointType = deserializedDto.DataPointType,
        PointTypeProperties = deserializedDto.PointTypeProperties.ToDictionary(p => p.PropertyName, p =>
            new PointTypeProperty
            {
                PropertyValue = p.PropertyValue,
                Requirement = p.Requirement
            })
    };
