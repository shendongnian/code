    A `JsonConverter` that generates JSON in this format would look like:
        public class BitArrayConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(BitArray);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var bools = serializer.Deserialize<bool[]>(reader);
                return bools == null ? null : new BitArray(bools);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, ((BitArray)value).Cast<bool>());
            }
        }
    With corresponding JSON:
    ```
    {
      "ID": "cb7f8e9e-a4a8-4cc5-b96f-c07779f91409",
      "Input": [
        true,
        true,
        false
      ],
      "Output": [
        true,
        true,
        false
      ],
      "Dirty": [
        false,
        false,
        false
      ]
    }
    ```
