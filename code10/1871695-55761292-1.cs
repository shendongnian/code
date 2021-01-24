    string[] numbers = File.ReadAllLines(@"numbers.txt");
    // Create a list we can add the numbers we're parsing to. 
    List<float> parsedNumbers = new List<float>() ;
    for (int i = 0; i < numbers.Length; i++) 
    {
        // Check if the current number is an empty line
        if (numbers[i].IsNullOrEmpty()) 
        {
            continue;
        }
        // If not, try to convert the value to a float
        if (float.TryParse(numbers[i], out float parsedValue))
        {
            // If the conversion was successful, add it to the parsed float list 
            parsedNumbers.Add(parsedValue);
        }
    } 
    // Convert the list to an array
    float[] floatArray = new float[parsedNumbers.Length];
