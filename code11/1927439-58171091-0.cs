`
void AddToList(string name, int count)
{
    // Go through entire list
    for (var i = 0; i < finalProducts.Count; i++) {
        var s = finalProducts[i];
        // Search for product name
        if (s.StartsWith(name)) {
           // TODO: put in try/catch
           // Get name and current count
           var parts = s.Split(new[] { " * " }, StringSplitOptions.None);
           // Increment
           var newCount = Int32.Parse(parts[1]) + count;
           // Update list
           finalProducts[i] = String.Format("{0} * {1}", name, newCount);
           return;
        }
    }
    // If we are here, it was not previously in list
    finalProducts.Add(String.Format("{0} * {1}", name, count));
}
`
Another option is to use a `Dictionary` instead of a `List`:
`
Dictionary<string, int> finalProducts = new Dictionary<string, int>();
`
Then adding becomes simpler:
`
void AddToList(string name, int count)
{
    // In the list already?
    if (finalProducts.ContainsKey(name)) {
        finalProducts[name] += count;
    }
    // No? Add it
    else {
        finalProducts[name] = count;
    }
}
