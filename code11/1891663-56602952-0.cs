csharp
var text = "Scelerisque suspendisse congue habitant scelerisque sociis placerat a himenaeos diam nunc vestibulum nec ultrices nisl himenaeos viverra mus hac.";
var ranges = new Range[]
{
    new Range(12, 39),
    new Range(24, 6),
    new Range(59, 30),
    new Range(80, 24),
    new Range(114, 14)
};
var rangedChars = new RangedChar[text.Length];
for (int i = 0; i < text.Length; i++)
    rangedChars[i] = new RangedChar(i, text[i], ranges.Where(r => r.ContainsIndex(i)));
var substrings = new List<RangedString>();
for (int i = 0; i < rangedChars.Length; )
{
    var appliedRanges = rangedChars[i].Ranges;
    int j = i + 1;
    while (j < rangedChars.Length && appliedRanges.SequenceEqual(rangedChars[j].Ranges))
        j++;
    var substring = String.Join("", text.Substring(i, j - i));
    substrings.Add(new RangedString(i, substring, appliedRanges));
    i = j;
}
return substrings;
// supporting types
readonly struct Range
{
    public int Start { get; }
    public int Length { get; }
    public Range(int start, int end) { Start = start; End = end; }
    public bool ContainsIndex(int index) => index >= Start && index < (Start + Length);
}
public class RangedChar
{
    public int Index { get; }
    public char Character { get; }
    public IReadOnlyList<Range> Ranges { get; }
    public RangedChar(int index, char character, IEnumerable<Range> ranges)
    {
        Index = index;
        Character = character;
        Ranges = ranges.ToList();
    }
}
public class RangedString
{
	public int Start { get; }
	public string Text { get; }
	public IReadOnlyList<Range> Ranges { get; }
	public RangedString(int start, string text, IEnumerable<Range> ranges)
	{
		Start = start;
		Text = text;
		Ranges = ranges.ToList();
	}
}
