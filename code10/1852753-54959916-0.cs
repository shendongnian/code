    var source = "File_name,cost_per_page,0.23,color_code,343,thickness,0.01";
    var splitted = source.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
    var result = new Dictionary<string, string>();
    // Note: Starting from 1 to skip the "file_name"
    // moving 2 indexes in each iteration, 
    // and ending at length - 2.
    for(int i = 1; i < splitted.Length - 1; i+=2)
    {
        result.Add(splitted[i], splitted[i+1]);
    }
