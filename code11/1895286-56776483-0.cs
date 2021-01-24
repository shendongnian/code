csharp
var tables = new List<(string, IQueryable, IQueryable)>
{
    ("Table A", source.TableA, destination.TableA),
    ("Table B", source.TableB, destination.TableB)
};
foreach (var (displayName, sourceTable, destinationTable) in tables)
{
    // Quick validation: in case you accidentally specified mismatched element types,
    // skip them for now.  Eventually, throw DeveloperException.
    if (sourceTable.ElementType != destinationTable.ElementType)
        continue;
    Console.WriteLine($"Processing {displayName}");
    destination.DbSet(destinationTable.ElementType).RemoveRange(destinationTable);
    destination.SaveChanges();
    destination.DbSet(destinationTable.ElementType).AddRange(sourceTable.AsNoTracking().ToList());
    destination.SaveChanges();
}
