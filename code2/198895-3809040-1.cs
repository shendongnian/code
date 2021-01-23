    using System.Text.RegularExpressions;
    str = "35|http:\/\/v10.lscache3.c.youtube.com\/videoplayback...";
    Regex r = new Regex(@"^[0-9]{1,2}");
    Match m = r.Match(str);    
    if(m.Success) {
        Console.WriteLine("Matched: " + m.Value);
    } else {
        Console.WriteLine("No match");
    }
