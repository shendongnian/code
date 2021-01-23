    public class CompositeIndicator: IIndicator
    {
         private MovingAverage _ma;
         public CompositeIndicator(/* your parameters here */)
         {
             _ma = new MovingAverage();
         }
         public double Calculate()
         {
             var mavalue = _ma.Calculate();
             //do more stuff
             return mavalue;
         }
    }
