    var lines = File.ReadAllLines("Questions.txt");
    var questions = new Dictionary<int, string>();
    foreach (var line in lines)
    {
        var parts = line.Split(new[] {". "}, StringSplitOptions.RemoveEmptyEntries);
        var number = Int32.Parse(parts[0]);
        questions.Add(number, parts[1]);
    }
