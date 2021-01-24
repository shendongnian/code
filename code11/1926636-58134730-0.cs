    using System.Text.RegularExpressions;
    string expr = @"\d+\)";
    string[] matches = Regex.Split(strType, expr);
    foreach(string m in matches){
        Console.WriteLine(m);
    }
