string sentence = "\"This is the end?\"";
var matches = Regex.Matches(sentence, "[\"?]");
var punctuationLocations = string.Empty;
foreach(Match match in matches)
{
	punctuationLocations += match.Value + " at index:" + match.Index + Environment.NewLine;
}
// punctuationLocations:
//   " at index:0
//   ? at index:16
//   " at index:17
