    public static IEnumerable<T> Range<T>(this IEnumerable<T> enumerable, Func<T,bool> selector, int size)
    {
        Queue<T> queue = new Queue<T>();
        bool found = false;
        int count = 0;
        foreach(T item in enumerable)
        {
                if(found)
                {
                    if(count++ < size)
                    {
                        yield return item;
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    if(queue.Count>size)
                        queue.Dequeue();
     
                    if(selector(item))
                    {
                        found = true;
                        foreach(var stackItem in queue)
                            yield return stackItem;
                        
                        yield return item;
                        
                        
                    }
                    else
                    {
                        queue.Enqueue(item);
                    }
                }
            }
