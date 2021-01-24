csharp
public sealed class StopCsvMapper : ClassMap<Stop>
{
    public StopCsvMapper()
    {
        Map(m => m.Id).Name("Id").Default(Guid.Empty);
        Map(m => m.Identifier).Name("Identifier");
        Map(m => m.Name).Name("Name");
        Map(m => m.Location).ConvertUsing(row =>
        {
            if (row.GetField("LocationId") != string.Empty)
            {
                return null;
            }
            else
            {
                return new Location
                {
                    Id = Guid.Empty,
                    Name = row.GetField("LocationName"),
                    Notes = row.GetField("LocationNotes"),
                    Latitude = row.GetField("LocationLatitude"),
                    Longitude = row.GetField("LocationLongitude"),
                };
            }
        });
    }
}
