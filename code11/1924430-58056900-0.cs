    public string[] lines = File.ReadAllLines(openFileDialog1.FileName);
    var filteredLines = new List<string>(lines);
    foreach(var line in lines)
    {
        var pair = line.Split(':');
        var mail = pair[0];
        var pass = pair[1]; // may throw exception on invalid format of your line
        for(int i = 1; i < pass.Length; i++)
        {
            if(pass[i] == pass[i - 1])
            {
                filteredLines.Remove(line);
                break;   // will break inner loop and continue on next line
            }
        }
    }
