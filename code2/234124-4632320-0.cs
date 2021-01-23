    class Tree<T> where T : Tree<T>
    {
        T parent;
        List<T> children;
        T Parent { get; set; }
        protected Tree(T parent) 
        {
            this.parent = parent; 
            parent.children.Add(this);
        }
        // lots more code handling tree list stuff
    }
