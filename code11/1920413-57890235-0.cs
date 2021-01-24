     if (args[0] == "prog1")
     {
        string[] lines = File.ReadAllLines(filename);
    
            for(int i = 0; i< lines.Length; i++)
            {
                var line = lines[i];
                if (line.Contains("Name"))
                {
                    Console.WriteLine(line);
                    Console.WriteLine(lines[++i]); // ++i means "increment i, then use it" so it is incremented first then used to access the line
                }
            }
    }
* Toggle a boolean on that will cause the next line to print even though it doesn't contain "Name", then toggle it off when you do the print
    if (args[0] == "prog1")
    {
        List<string> lines = File.ReadAllLines(filename).ToList();
    
            bool toggle = false;
            foreach (var line in lines)
            {
                if (line.Contains("Name"))
                {
                    toggle = true;
                    Console.WriteLine(line);
                }
                if(toggle){
                    Console.WriteLine(line);
                    toggle = false;
                }
            }
    }
You should add some error checking that prevents the ++i causing a crash if the last line of the file contains "Name"
