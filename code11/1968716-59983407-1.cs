    var input = "Maison 42 / Salle de bains /01-Points d'eau/ 01-01 Vasques";
		
	string pattern = @"\s*/\s*";
	string replacement = "/";
    // using System.Text.RegularExpressions;
	Regex rgx = new Regex(pattern);
	string result = rgx.Replace(input, replacement);
