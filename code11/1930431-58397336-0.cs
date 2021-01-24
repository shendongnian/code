c#
public static DateTime ProcessDateTimeV2Date(this EntityModel entity)
{
    if (entity.AdditionalProperties.TryGetValue("resolution", out dynamic resolution))
    {
        var resolutionValues = (IEnumerable<dynamic>) resolution.values;
        var datetimes = resolutionValues.Select(val => DateTime.Parse(val.value.Value));
        if (datetimes.Count() > 1)
        {
            // assume the date is in the next 7 days
            var bestGuess = datetimes.Single(dateTime => dateTime > DateTime.Now && (DateTime.Now - dateTime).Days <= 7);
            return bestGuess;
        }
        return datetimes.FirstOrDefault();
    }
    throw new Exception("ProcessDateTimeV2DateTime");
}
public static string ProcessRoom(this EntityModel entity)
{
    if (entity.AdditionalProperties.TryGetValue("resolution", out dynamic resolution))
    {
        var resolutionValues = (IEnumerable<dynamic>) resolution.values;
        return resolutionValues.Select(room => room).FirstOrDefault();
    }
    throw new Exception("ProcessRoom");
}
