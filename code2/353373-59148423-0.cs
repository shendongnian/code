    public IEnumerable<string> Tokenize(params string[] words)
    {
      ...
    }
    
    var items = Tokenize(product.Name, product.FullName, product.Xyz)
