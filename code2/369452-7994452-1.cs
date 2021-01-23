    public class Fruit
    {
        public event EventHandler<RipeEventArgs> Ripe;
    }
    
    public class Apple:Fruit
    {
        public event EventHandler<FallEventArgs> FallFromTree;
    }
    
    public class Farm
    {
        List<Fruit> fruits;
        Farmer farmer;
    
        public Farm(Farmer farmer)
        {
            this.farmer = farmer;
        }
    
        public void AddFruit(Fruit fruit)
        {
            farmer.RegisterForEvents(fruit);
            fruits.Add(fruit);
        }
    }
    
    public class Farmer
    {
        private Farm myFarm;
    
        public Farmer()
        {
            
        }
    
        public virtual void RegisterForEvents(Fruit fruit)
        {
           //Farmer decides what events it is interested in: can override in derived classes
           if(fruit is Apple)
           {
               ((Apple)fruit).FallFromTree += AppleFallen;
           }
        }
    
        public void AppleFallen(object sender, FallEventArgs e) {}
    }
