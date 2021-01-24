    public class MyLabel:Label
    {      
        public MyLabel()
        {
            
        }
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if(heightConstraint>40)
            {
                return new SizeRequest(new Size(widthConstraint,40));
            }
            return base.OnMeasure(widthConstraint, heightConstraint);
        }
    }
