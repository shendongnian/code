    public void Eat(ILiving food)
    {
        food.LifeStatus = LifeStatus.Dead;
        return food;
    }
