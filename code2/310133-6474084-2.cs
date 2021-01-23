    public bool TryGetOrAddBanana(string name, out Banana banana) 
    {
        banana = this.Bananas.FirstOrDefault(b => b.Name == name);
        if (banana == null)
        {
            if (this.IsFull) return false;
            banana = new Banana { Name = name };
            this.Bananas.Add(banana);
        }
        return true;
    }
