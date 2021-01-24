    string[] lines =
    {
        "email1:1234567895121",
        "email2:12345",
        "email3:22222222222",
        "email4:11111",
        "email5:454545454545"
    };
    lines = lines
        .Where(s =>
        {
            string pass = s.Split(new[] { ':' }, 2)[1];
            return pass.Length >= 8 && pass.Any(c => c != pass[0]);
        })
        .ToArray();
    foreach (var s in lines)
        Console.WriteLine(s);
