    public enum Fruits
    {
        Apple = 1,
        Orange = 2,
        Grapes = 4
    }
    public Fruits Fruit
    {
        get
        {
            return m_fruits;
        }
        set
        {
            if (!Enum.IsDefined(typeof(Fruits), value))
            {
                throw new ArgumentException();
            }
            m_fruits = value;
        }
    }
