    for(int i = 0; i < filesToCopy.Count; i++) {
        try {
            // Copy the file
        } catch(Exception ex) {
            // Rollback
            while(--i >= 0) {
                System.IO.File.Delete(filesToCopy[i]); // For example
            }
    
            break;
        }
    }
