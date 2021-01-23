    public class MathCalculations
    {
        public Int32 getRandom(Int32 iMin, Int32 iMax)
        {  
            Random rnd = new Random();
            return rnd.Next(iMin, iMax);
        }
    }
    public class Main
    {
        MathCalculations mathCalculations = new MathCalculations();
        for (int i = 0; i < 6; i++)
        {
            getRandom(0,1000);
        }
    }
