    public void Main()
    {
        _cat = new CatClass();
        _cat.CatType = CatType.Active;
        Console.WriteLine(_cat.CatType.ToString());
    }
