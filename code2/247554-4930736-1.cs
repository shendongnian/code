    public IEnumerable<Effect> EffectsNotRecursive() 
    {     
        var stack = new Stack<Effect>();
        stack.Push(this);
        while(stack.Count != 0)
        {
            var current = stack.Pop();
            yield return current;
            foreach(var child in current.Effects)
                stack.Push(child);
        }
    }
