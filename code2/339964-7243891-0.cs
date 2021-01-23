    System.IO.File.WriteAllLines(
        "outfilename.txt",
        System.IO.File.ReadAllLines("infilename.txt").Select(line =>
            System.Text.RegularExpression.Regex.Replace(line, @"\s+", "|")
            )
        ).ToArray()
    );	
