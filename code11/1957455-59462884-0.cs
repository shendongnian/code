using System.Linq.Dynamic.Core;
[...]
IReadOnlyList<String> userSelectedPropertyList = ...
// e.g. userSelectedPropertyList = new[] { "FirstArtist", "Title" };
String dynamicLinqGroupByKeySelector = "new (" + String.Join( ", ", userSelectedPropertyList ) + ")";
// so the GroupBy keySelector looks like "new (FirstArtist, Title)".
var query = MusicFiles
    .GroupBy( dynamicLinqGroupByKeySelector )
    .Where( g => g.Count() > 1 )
    .ToList();
  [1]: https://stefh.github.io/System.Linq.Dynamic.Core/html/82cab2b4-8a2a-f0b1-0b02-004e75f7e79f.htm
