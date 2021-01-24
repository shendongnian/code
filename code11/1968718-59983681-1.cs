    using System.Text.RegularExpressions;
    ...
    // two spaces after 1st '/'; no spaces before 2nd '/' 
    string source = "Salle de bains /  01-Points d'eau/ 01-01 Vasques";
    string result = Regex.Replace(source, @"\s*/\s*", "/"); 
    Console.Write(result);
