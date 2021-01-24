csharp
public static int IndexOf(this string s, string[] values) {
    var found = values
        .Select(v => s.IndexOf(v))
        .Where(index => index >= 0)
        .OrderBy(v => v)
        .Take(1)
        .ToList();
    return found.Count > 0 ? found[0] : -1;
}
**EDIT:** Removing -1 values
