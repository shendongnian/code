    Queue<string> queue=new Queue<string>();
    HashSet<string> allItems=new HashSet<string>();
    
    void Add(string item)
    {
      if(allItems.Add(item))
        queue.Enqueue(item);
    }
    
    void DoWork()
    {
        while(queue.Count>0)
        {
          var value=queue.Dequeue();
          ...
        }  
    }
