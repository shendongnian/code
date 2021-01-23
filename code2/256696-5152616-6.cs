    for(int i = 0; i < ftd.Count; i++) {
       if (string.IsNullOrEmpty(arr[0])) {
          ftd.RemoveAt(i);
          i--; // Adjust for One less
       }
    }
    
