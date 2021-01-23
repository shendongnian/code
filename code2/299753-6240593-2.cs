    class ComboBoxItem
    {
    public string Name;
    public int Value;
    public ComboBoxItem(string Name, int Value)
    {
    this.Name = Name;
    this.Value = Value;
    }
    // override ToString() function
    public override string ToString()
    {
    return this.Name;
    }
    }
