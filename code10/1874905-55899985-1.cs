    string[] lines = File.ReadAllLines(YOUR_FILE PATH);
    
    int[] array = new int[lines.Length];
    
    int i =0; 
    foreach(var line in lines)
    {
    	array[i] = int.Parse(line);
        i++;
    }
