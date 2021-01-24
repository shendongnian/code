    using System.Text.RegularExpressions;
    ... 
    string source = "some text with 1.2.34.4893-beta1 version" ;
    if (Version.TryParse(Regex.Match(source, @"[0-9]+(?:\.[0-9]+)+").Value, out var version)) {
      // version  extracted
    }
    else {
      // source doesn't have a match
    }
