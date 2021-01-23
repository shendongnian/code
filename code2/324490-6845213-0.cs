    interface ICommonStuff
    {
        string getDescription();
    }
    
    public class Beverage : ICommonStuff { }
    
    public class BeverageDecorator : ICommonStuff
    {
        public BeverageDecorator(Beverage b) { }
    }
