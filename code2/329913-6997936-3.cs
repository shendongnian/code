    class VehicleConverter : JsonCreationConverter<Vehicle>
    {
        protected override Type GetType(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Type");
            switch (type)
            {
                case "Car":
                    return typeof(Car);
                case "Bike":
                    return typeof(Bike);
            }
            throw new ApplicationException(String.Format(
                "The given vehicle type {0} is not supported!", type));
        }
    }
