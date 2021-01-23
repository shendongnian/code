    class Parent
    {
      ...
      public Child AddChild(string name)
      {
        return this.AddChild(new Child(name));
      }
      public Child AddChild(Child c)
      {
        c.Parent = this;
        this.children.Add(c);
    
        return c;
      }
    }
