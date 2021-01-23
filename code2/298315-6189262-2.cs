    public class Mercedes : CarBase
    {
        public override void ChangeColor(string color)
        {
             if (color == red)
                 AddRacingTires();
        }
    } 
