    static void Main()
    {
        var file = @"C:\Users\gurudeniyas\Desktop\CobolData.txt";
        var lines = File.ReadAllLines(file).ToList();
        var records = new List<Record>();
        for (var count = 0; count < lines.Count; count++)
        {
            var line = lines[count];
            var firstTwo = line.Substring(0, 2);
            // Iterate till we find a line that starts with 01
            if (firstTwo == "01")
            {
                // Create a Record and add 01 line related data
                var rec = new Record
                {
                    OneInfo = Extract01Data(line)
                };
                // Here we iterate to find preceding lines that start with 03
                // If we find them, extract 04 data and add as a record
                // Break out of the loop if we find the next 01 line or EOF
                do
                {
                    count++;
                    if (count == lines.Count)
                        break;
                    line = lines[count];
                    firstTwo = line.Substring(0, 2);
                    if (firstTwo == "04")
                    {
                        rec.FourInfo.Add(Extract04Data(line));
                    }
                } while (firstTwo != "01");
                // If we found next 01, backtrack count by 1 so in the outer loop we can process that record again
                if (firstTwo == "01")
                {
                    count--;
                }
                records.Add(rec);
            }
        }
        Console.ReadLine();
    }
