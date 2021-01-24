    public class Minute : TimeMulti
    {
        public float Mult1 { get; set; }
        public float Mult2 { get; set; }
        public float Mult3 { get; set; }
        public float Mult4 { get; set; }
        // MultCount = 4
        public Minute(): base(4) { }
        // This method will set the value of the property using switch statment, with this, you will avoid Reflection. 
        protected override float SetMult(int multNumber, float multValue)
        {
            switch (multNumber)
            {
                case 1:
                    Mult1 = multValue;
                    break;
                case 2:
                    Mult2 = multValue;
                    break;
                case 3:
                    Mult3 = multValue;
                    break;
                case 4:
                    Mult4 = multValue;
                    break;
            }
            return multValue;
        }   
    }
