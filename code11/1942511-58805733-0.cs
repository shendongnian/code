    var names = new List<string>
    {
    	"Table1", "SomeRandomName", "Table8907123", "Table123NoMatch"
    };
    
    var regex = new Regex(@"^Table[1-9]\d*$");
    
    var matches = names.Select(s => regex.Match(s)).Where(match => match.Success);
    foreach (var match in matches)
    	ViewData.Add($"{match.Value}FillColor", "#ff1200");
