    for(int i = 0; i < ftd.Count; i++) {
       if (string.IsNullOrEmpty(arr[0])) {
          ftp.RemoveAt(i);
          i--; // Adjust for One less
       }
    }
    
