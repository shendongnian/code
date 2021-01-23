                Queue<string> qu = new Queue<string>();
                bool finished = false;
                Task.Factory.StartNew(() =>
                {
                    Parallel.ForEach(get_list(), (item) =>
                    {
                        string itemToReturn = heavyWorkOnItem(item);         
                        lock (qu)
                           qu.Enqueue(itemToReturn );                        
                    });
                    finished = true;
                });
    
                while (!finished)
                {
                    lock (qu)
                        while (qu.Count > 0)
                            yield return qu.Dequeue();
                    //maybe a thread sleep here?
                }
