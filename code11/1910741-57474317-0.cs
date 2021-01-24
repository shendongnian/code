    string[] tmp = File.ReadAllLines(textfile);
    List<string> Content = new List<string>();
    bool dumpA = false;
    Regex regBEGIN = new Regex(@"<TestInfo\.""Content"">");
    Regex regEND = new Regex(@"<TestInfo\.""Content2"">");
    foreach (string line in tmp)
    {
        if (dumpA)
           Content.Add(line.Trim());
           if (regBEGIN.IsMatch(line))
              dumpA = true;
           if (regEND.IsMatch(line)) break;
    }
