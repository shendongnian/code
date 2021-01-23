    public abstract class condimentDecorator : Beverage
    {
         public override string getDescription()
         {
              return getDescriptionInternal();
         }
         protected abstract string getDescriptionInternal();
    }
