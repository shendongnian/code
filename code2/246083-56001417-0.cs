    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    // ...
    var results = Regex.Matches(s, @"<<(.*?)>>", RegexOptions.Singleline)
		 		.Cast<Match>()
		 		.Select(x => x.Groups[1].Value);
