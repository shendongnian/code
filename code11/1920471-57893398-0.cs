    public class MeasurementInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MeasurementInfo);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            MeasurementInfo info = new MeasurementInfo();
            info.Instrument = obj["Instrument"].ToObject<Instrument>(serializer);
            info.MinReading = ReadPhysical(obj, "Min Reading", info.Instrument);
            info.MaxReading = ReadPhysical(obj, "Max Reading", info.Instrument);
            info.AmbientTemperature = ReadPhysical(obj, "Ambient Temperature", Instrument.Thermometer);
            return info;
        }
        private Physical ReadPhysical(JObject obj, string name, Instrument instrument)
        {
            Dimension dim = Dimension.Force;
            switch (instrument)
            {
                case Instrument.WeightScale: dim = Dimension.Weight; break;
                case Instrument.Chronometer: dim = Dimension.Time; break;
                case Instrument.Thermometer: dim = Dimension.Temperature; break;
                case Instrument.Caliper:     dim = Dimension.Displacement; break;
            }
            string[] parts = ((string)obj[name]).Split(new char[] { ' ' }, 2);
            Physical physical = new Physical()
            {
                Dimension = dim,
                Value = double.Parse(parts[0]),
                Unit = parts[1]
            };
            return physical;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MeasurementInfo info = (MeasurementInfo)value;
            JObject obj = new JObject();
            obj.Add("Instrument", JToken.FromObject(info.Instrument, serializer));
            WritePhysical(obj, "Min Reading", info.MinReading);
            WritePhysical(obj, "Max Reading", info.MaxReading);
            WritePhysical(obj, "Ambient Temperature", info.AmbientTemperature);
            obj.WriteTo(writer);
        }
        private void WritePhysical(JObject obj, string name, Physical physical)
        {
            obj.Add(name, physical.Value.ToString("N0") + " " + physical.Unit);
        }
    }
