    void Main()
    {
        int maxQueueSize = 50;
        var lines = File.ReadAllLines(filePath);
        Queue<string> q = new Queue<string>(lines);
        // Here you should check for files bigger than your limit    
        ....
 
        // Trying to add too many elements
        for (int x = 0; x < maxQueueSize * 2; x++) 
        {
            // Remove the first if too many elements
            if(q.Count == maxQueueSize)
                q.Dequeue();
            // as an example, add the x converted to string                
            q.Enqueue(x.ToString());
            
        }
        // Back to disk
        File.WriteAllLines(filePath, q.ToList());
    }
