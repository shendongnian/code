[JsonConverter(typeof(DecimalJsonConverter))]
public decimal? FielDecimalX { get; set; }
I've wrote a class to handle the conversion like in this [solution][1]
    public class DecimalJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(reader.Value, CultureInfo.InvariantCulture);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((decimal)value).ToString("G6", CultureInfo.InvariantCulture));
        }
    }
I took "G6" for my needs. If a value is greater than 5 decimal the output is x.yE-05 for a decimal value 0.0000xy but javascript reconize correctly this format number.
So output from my API .net core 2.2 returns this json :
{
"eau": 7.83,
"naCl": 0.5,
"orga": 7.2E-05,
"k1": null,
}
Hope that performance are not broken by this change, but i don't see any problems. Thus, i can save payload on my requests.
Hope it helps !
  [1]: https://stackoverflow.com/questions/34568963/how-can-i-force-a-minimum-number-of-decimal-places-in-json-net
