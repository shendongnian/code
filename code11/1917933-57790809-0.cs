    public IEnumerable<MyClassWithChildren> GetAllChildren()
    {
        var items = new Queue<MyClassWithChildren>();
        items.Enqueue(this);
        
        while (items.TryDequeue(out var result))
        {
            yield return result;
            
            for (var i = 0; i < result.m_children.Length; ++i) // use for instead of foreach to avoid enumerator creation
            {
                items.Enqueue(result.m_children[i]);
            }
        }
    }
