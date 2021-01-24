    A converter for this format would look like:
        public class BitArrayConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(BitArray);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var bytes = serializer.Deserialize<byte[]>(reader);
                return bytes == null ? null : new BitArray(bytes);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, ((BitArray)value).BitArrayToByteArray());
            }
        }
        public static class BitArrayExtensions
        {
            // Copied from this answer https://stackoverflow.com/a/4619295
            // To https://stackoverflow.com/questions/560123/convert-from-bitarray-to-byte
            // By https://stackoverflow.com/users/313088/tedd-hansen
            // And made an extension method.
            public static byte[] BitArrayToByteArray(this BitArray bits)
            {
                byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
                bits.CopyTo(ret, 0);
                return ret;
            }
        }
    With corresponding JSON:
    ```
    {
      "ID": "2df93cf8-d28f-40d5-9959-46afc1679d5d",
      "Input": "fw==",
      "Output": "fw==",
      "Dirty": "AA=="
    }
    ```
