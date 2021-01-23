    public override string ToString()
    {
        List<string> names = new List<string>();
        names.Add(this.Name);
        Category parent = this.Parent;
        while (parent != null)
        {
            names.Add(parent.Name);
            parent = parent.Parent;
        }
        names.Reverse();
        return string.Join(" > ", names);
    }
