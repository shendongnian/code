var xml = @"<root>
    <MIME>
        <MIME_SOURCE>\Web\Bilder Groß\1509_131_021_01.jpg</MIME_SOURCE>
    </MIME>
    <MIME>
        <MIME_SOURCE>\Web\Bilder Groß\1509_131_021_01_MitWasserzeichen.jpg</MIME_SOURCE>
    </MIME>
    <MIME>
        <MIME_SOURCE>\Web\Bilder Groß\icon_top.jpg</MIME_SOURCE>
    </MIME>
</root>";
var replacements = new Dictionary<string, string>()
{
    {@"\Web\Bilder Groß\1509_131_021_01.jpg", "/Web/Bilder Groß/1509_131_021_01.jpg"},
    {@"\Web\Bilder Groß\1509_131_021_01_MitWasserzeichen.jpg", "/Web/Bilder Groß/1509_131_021_01_MitWasserzeichen.jpg"},
    {@"\Web\Bilder Groß\icon_top.jpg", "icon_top.jpg"},
    {@"\Web\Bilder klein\5478.jpg", "5478.jpg"}
};
var doc = XDocument.Parse(xml);
foreach (var source in doc.Root.Descendants("MIME_SOURCE"))
{
    if (replacements.TryGetValue(source.Value, out var replacement))
    {
        source.Value = replacement;
    }
}
var result = doc.ToString();
If you can make some assumptions about how your XML is structured (e.g. no whitespace between the `<MINE_SOURCE>` tags, no attributes, etc), then you can use some regex, allowing you to again make a single pass:
var result = Regex.Replace(xml, @"<MIME_SOURCE>([^<]+)</MIME_SOURCE>", match =>
{
    if (replacements.TryGetValue(match.Groups[1].Value, out var replacement))
    {
        return $"<MIME_SOURCE>{replacement}</MIME_SOURCE>";
    }
    return match.Value;
});
You'll have to benchmark different approaches yourself on your own data. Use [BenchmarkDotNet](https://benchmarkdotnet.org/).
