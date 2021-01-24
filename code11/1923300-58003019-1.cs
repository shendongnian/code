    static void Main(string[] args)
    {
        var questions = new List<(ulong channel, ulong user, object answer)>
        {
            (1, 1, 1),
            (2, 2, 2),
            (3, 3, 3),
            (4, 4, 4)
        };
        foreach (var (channel, user, answer) in questions)
        {
            Console.WriteLine(answer);
        }
        var channel3Index = questions.FindIndex((obj) => obj.channel == 3);
        if (channel3Index > -1)
        {
            var question = questions[channel3Index];
            question.answer = 666;
            questions[channel3Index] = question;
        }
        foreach (var (channel, user, answer) in questions)
        {
            Console.WriteLine(answer);
        }
        Console.ReadKey();
    }
