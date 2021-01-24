C#
public static class Localization
{
  public static Task<List<string>> Available { get; private set; }
  static Localization() => Available = LoadMetaDataAsync();
  private static async Task<List<string>> LoadMetaDataAsync()
  {
    var results = new List<string>();
    ...
      results.Add(lang);
    return results;
  }
}
Usage:
C#
private async Task StartAsync()
{
  var languages = await Localization.Available;
  Debug.Log(languages.Available.Count);
}
