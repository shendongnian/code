csharp
List<Block> blocks = new List<Block>();
List<Presence> presences = new List<Presence>();
Dictionary<Block, IEnumerable<Presence>> filteredList = blocks.FilterPresences(presences);
foreach (KeyValuePair<Block, IEnumerable<Presence>> pair in filteredList)
{
	Console.WriteLine($"Total flight time between \"{pair.Key.Start} - {pair.Key.End}\" is \"{pair.Value.GetTotalFlightTime()}\"");
}
