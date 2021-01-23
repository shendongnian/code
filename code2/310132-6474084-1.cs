    public Banana GetOrAddBanana(string name) 
    {
        var banana = this.Bananas.FirstOrDefault(b => b.Name == name);
        if (banana == null)
        {
            if (this.IsFull) throw new Exception("Collection is full");
            banana = new Banana { Name = name };
            this.Bananas.Add(banana);
        }
        return banana;
    }
