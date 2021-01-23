    public interface IApple{
        int I {get; set;}
        int J {get; set;}
    }
    
    public class GrannySmith : IApple{
        
        public GrannySmith()
        {
            this.I = 10;
            this.J = 6;
        }
        int I {get; set;}
        int J {get; set;}
    }
    
    public class FruitUtils{
        public int CalculateAppleness(IApple apple)
        {
             return apple.J * apple.I;
        }
    }
