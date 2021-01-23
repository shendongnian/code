    string input = "...";
    var r = input.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries) // split by .
                 .Select(s => String.Format("\"{0}\"", s.Trim())); // escape each with quotes
    input = String.Join(Environment.NewLine, r); // break by line break
    
