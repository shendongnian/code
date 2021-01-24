    public class InvoiceAmountsAsStringsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PosInvoice);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            PosInvoice invoice = (PosInvoice)value;
            JsonObjectContract contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(typeof(PosInvoice));
            writer.WriteStartObject();
            foreach (JsonProperty prop in contract.Properties)
            {
                writer.WritePropertyName(prop.PropertyName);
                object propValue = prop.ValueProvider.GetValue(invoice);
                if (propValue is decimal)
                {
                    writer.WriteValue(((decimal)propValue).ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    serializer.Serialize(writer, propValue);
                }
            }
            writer.WriteEndObject();
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
