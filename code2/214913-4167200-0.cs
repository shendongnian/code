    interface IFlyable
    {
        void Fly();
    }
    
    class Bird : IFlyable
    {
        public void Fly() { }
    }
    
    class Plane : IFlyable
    {
        public void Fly() { }
    }
    List<IFlyable> things = GetBirdInstancesAndPlaneInstancesMixed();
    foreach(IFlyable item in things)
    {
       item.Fly();
    }
