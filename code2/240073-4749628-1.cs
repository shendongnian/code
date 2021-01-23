    public IEnumerable<Product> GetProductsByName(string name) {
        return GetProductsByExpression(p => p.Name == name);
    }
    private IEnumerable<Product> GetProductsByExpression(
        Expression<Func<Product, bool>> expression
    ) {
        return _repository.FindAll(expression);
    }
