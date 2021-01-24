 c#
public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // You should do some fool proof parsing here
	    var s = reader.GetString();
		s=s.Replace("/Date(","");
		s=s.Replace(")/","");
		long epoch = Convert.ToInt64(s);
		DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(epoch);
        return dateTimeOffset.UtcDateTime;
    }
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // Do some conversion here
    }
}
Here is a .net fiddle:
https://dotnetfiddle.net/tAK62c
