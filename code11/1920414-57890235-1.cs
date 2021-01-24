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
* Keep using the foreach and toggle a boolean to true, that will cause the next line to print even though it doesn't contain "Name", then toggle it off when you do the print
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
You should add some error checking that prevents the ++i causing a crash if the last line of the file contains "Name" - currently the code will just increment past the end of the array and then try to access it, causing a crash. 
Handling this could take the form of something as simple as running to `i < Length - 1` so it stops on the second to last line
Strictly speaking you don't need to use a list - `File.ReadAllLines` returns an array, and turning it to a list is a relatively expensive operation to perform if you don't need to. If all you will do is iterate it or change the content of individual lines (but not add or remove lines), leave it as an array of string. Using a List would make your life easier if you plan to manipulate it by inserting new lines etc 
