    public class myObject 
    {
        public decimal Prop1 {get;set;}
        public decimal Prop2 {get;set;}
        public decimal Prop3 {get;set;}
        
        public bool AreTheyEqual()
        {
            if (Prop1 == Prop2 && Prop2 == Prop3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
