    class ImplementFoo : IFoo
    {
        List<Thing1> m_things;
        IEnumerable<IThingy> Thingies 
        {
            get
            {
                return m_things.Cast<IThingy>();
            }
        }
    }
