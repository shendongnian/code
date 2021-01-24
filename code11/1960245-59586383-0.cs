private bool Check(string name, Func<string, string, bool> compareNames)
{
  // ...
  for(...)
  {
    string displayName = ... subkey get common code ...
    if (compareNames(name, displayName))
    {
      // ...
    }
  }
  // ...
}
public bool ExactCheck(string name) => Check(
    (name, displayName) => name.Equals(displayName, StringComparison.OrdinalIgnoreCase))
);
public bool VagueCheck(string name) => Check(
    (name, displayName) => displayName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0
);
