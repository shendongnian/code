    static void Main()
    {
        var file = @"CobolData.txt";
        var lines = File.ReadAllLines(file).ToList();
        var records = new List<Record>();
        // For this algorithm to work a `for` loop instead of a `foreach` is necessary.
        for (var count = 0; count < lines.Count; count++)
        {
            var line = lines[count];
            var firstTwo = line.Substring(0, 2);
            // We iterate till we find a line starts with `01`
            if (firstTwo == "01")
            {
                // Once a line starting with 01 is found, create a Record
                // and extract data corresponding to 01 line.
                var rec = new Record
                {
                    OneInfo = Extract01Data(line)
                };
                // From here on, the goal is to iterate till we find a 04 line.
                // If we do find one, we get that data and then break out of the loop
                // Else we go on till we find the next 01 (or EOF)
                // If we find the next01, we decrease count by one, and let the control to the main for loop and start over for the next 01 cycle.
                count++;
                do
                {
                    line = lines[count];
                    firstTwo = line.Substring(0, 2);
                    if (firstTwo == "04")
                    {
                        rec.FourInfo = Extract04Data(line);
                        break;
                    }
                    count++;
                } while (firstTwo != "01");
                if (firstTwo == "01")
                {
                    count--;
                }
                records.Add(rec);
            }
        }
        Console.ReadLine();
    }
