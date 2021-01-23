    public List<int> GetReferencedDocuments()
    {    
        var referencedIds = new List<int>();
        var queue = new Queue<Document>(this);
        while (queue.Count > 0)
        {
             var newDocuments = queue.Dequeue().Children
                                               .Where(d => !referencedIds.Contains(d.ID))
             foreach (Document newDocument in newDocuments) 
             {
                 queue.Enqueue(newDocument);
                 referencedIds.Add(newDocument.ID);
             }
        }
        return referencedIds;
    }
