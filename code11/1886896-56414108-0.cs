        string[] lines = File.ReadAllLines(INILoc);
        //create a list to hold the lines
        List<string> output = new List<string>();
        //loop through each line
        foreach (string line in lines)
        {
            //add current line to  ouput.
            output.Add(line);
            //check to see if our line includes the searched text;
            if (line.Contains("[names]"))
            {
                //output to the file and then exit loop causing all lines below this 
                //one to be skipped
                File.WriteAllText(INILoc, output.ToArray());
                break;
            }
        }
