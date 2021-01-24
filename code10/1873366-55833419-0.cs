 C#
// Keep a dictionary for count
var lineItemDict = new Dictionary<string, int>();
foreach (var inv in invoices)
{
    foreach (var line in inv.lines)
	{
		// If the rowtype already exists, increment the count
	    if (lineItemDict.ContainsKey(line.rowtype))
		{
		    lineItemDict.TryGetValue(line.rowtype, out count);
		    lineItemDict[line.rowtype] = count + 1;
		}
		else
		{
		    // Else add a new entry
		    lineItemDict.Add(line.rowtype, 1);
		} 
	}
}
With LINQ:
 C#
// Keep a dictionary for count
var lineItemDict = new Dictionary<string, int>();
invoices.ForEach(inv => {
    inv.lines.ForEach(line => {
	    // If the rowtype already exists, increment the count
	    if (lineItemDict.ContainsKey(line.rowtype))
		{
		    lineItemDict.TryGetValue(line.rowtype, out count);
		    lineItemDict[line.rowtype] = count + 1;
		}
		else
		{
		    // Else add a new entry
		    lineItemDict.Add(line.rowtype, 1);
		}
	
	});
});
Both of these will leave you with a dictionary (`lineItemDict`) that looks like this:
<rowtype> : <count>
For example,
'A' : 34
'B' : 3
'X' : 21
