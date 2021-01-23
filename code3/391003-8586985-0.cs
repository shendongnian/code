    string input = "test12345.txt";
    // replace all numbers with a single *
    string replacedstar = Regex.Replace( input, "[0-9]{2,}", "*" );
    // replace remaining single digits with ?
    string replacedqm = Regex.Replace( input, "[0-9]", "?" );
