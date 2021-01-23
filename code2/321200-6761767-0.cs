    string sPattern = "^09[-.\\s]?\\d{2}[-.\\s]?\\d{3}[-.\\s]?\\d{4}$";
    if (System.Text.RegularExpressions.Regex.IsMatch(stringToMatch, sPattern)){
       System.Console.WriteLine("Phone Number is valid");
    } else {
       System.Console.WriteLine("Phone Number is invalid");
    }
