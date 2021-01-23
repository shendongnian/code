    public IEnumerable<MyClass> Ancestors
    {
        get
        {
            MyClass current = this;
            while(current != null)
            {
                current = current.Parent;
                yield return current;
            }
        }
    }
