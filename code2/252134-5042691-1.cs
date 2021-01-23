        public interface ISomeBehavior
        {
            int Sample();
        }
    
        public class A : ISomeBehavior
        {
            int ISomeBehavior.Sample()
            {
                return 1;
            }
        }
    
       static class SomeExtension
       {
           public static int Sample(this ISomeBehavior obj)
           {
               return 2;
           }
       }
