    public void Assign(int data)
    {
        if (this.root == null)
        {
            this.root = new ChildClass(data);
        }
        else
        {
            this.root.data = data;
        }
    }
    public void Assign(ChildClass root)
    {
        this.root = root;
    }
