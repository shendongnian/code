     public interface Demo
        {
            int PredictRating(int param1);
        }
    
        public abstract class AbstractDemo : Demo
        {
            public virtual int PredictRating(int param1)
            {
                return param1 + 1;
            }
        }
    
        public class ClassDemo1 : AbstractDemo
        {
            //This guy uses AbstractDemo Predict Rating
            public override int PredictRating(int param1)
            {
                return base.PredictRating(param1);
            }
        }
    
        public class ClassDemo2 : AbstractDemo
        {
            //This guy overrides the predict rating behavior
            public override int PredictRating(int param1)
            {
                return param1 + 2;
            }
        }
