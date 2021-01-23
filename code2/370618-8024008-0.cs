    public void Render()
    {
        DoRender()
    
        foreach (var child in _children)
        {
            child.Render();
        }
    }
    
    protected virtual void DoRender()
    {
    }
