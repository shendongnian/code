    // In CoffeeDecorator
    public virtual double getCost()
    {
        return decoratedCoffee.getCost();
    }
    // In Milk
    public override double getCost()
    {
        return base.getCost() + cost;
    }
