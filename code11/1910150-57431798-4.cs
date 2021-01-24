    string[] parts = text.Split(new string[] {delimiter}, StringSplitOptions.None);
    int[] pos = new pos[parts.Length];
    
    for (int sum = 0, i = 0; i < parts.Length; sum += delimiter.Length + parts[i].Length, ++i) 
      pos[i] = sum; 
