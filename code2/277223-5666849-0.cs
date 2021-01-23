    public class Adjustment
    {
        public decimal Amount {get;set;}
        public bool IsCompounded {get;set;}
        public bool Add{get;set;}
    
        public decimal Calculate()
        {
            if(IsCompounded)
                return 1 + Amount / 100.0M;
            else
                return Amount / 100.0M;
        }
     }
    void Main()
    {
        List<Adjustment> adjustments = new List<Adjustment>();
        adjustments.Add(new Adjustment() {Amount = 10.0M, IsCompounded = false, Add = true});
        adjustments.Add(new Adjustment() {Amount = 7.0M, IsCompounded = false, Add = true};);
    
        decimal value = 0.0M;
        decimal total = 100.0M;
    
        foreach(Adjustment a in adjustments)
        {
            value = a.Calculate();
            
            if(a.IsCompound)
            {
                if(a.Add)
                     total *= value;
                 else
                     total /= value;
            }
            else
            {
                if(a.Add)
                     total += value; //should be a sum for nom-compounded
                 else
                     total -= value;
            }
        }
    
        Console.WriteLine(total);
    }
