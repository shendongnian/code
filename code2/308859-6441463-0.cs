    var input = "\r\n21.what is your favourite pet name?\r\nA.Cat B.Dog\r\nC.Horse D.Snake\r\n22.Which country produce wheat most?\r\nA.Australia B.Bhutan\r\nC.India D.Canada.";
    var regex = new Regex(@"(?<number>[0-9]+)\.(?<question>.+\?)\W+((?<letter>[A-Z])\.(?<answer>\w+)\W*)+");
    foreach (Match question in regex.Matches(input))
    {
        Console.Write("{0}. ", question.Groups["number"].Captures[0]);
        Console.WriteLine(question.Groups["question"].Captures[0]);
        foreach (Capture answer in question.Groups["answer"].Captures)
        {
            Console.WriteLine(answer.Value);
        }
    }
