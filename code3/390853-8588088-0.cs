    public GiftCard 
    { 
         private int _id;
         private double _amount;
         public int Id 
         { 
             get { return _id; } 
             set { _id = value; }
         } 
         public double Amount 
         { 
             get { return _amount; }
             set { _amount = value; } 
         } 
         public void ReduceAmount(double amount) 
         {
             // Validation checks to make sure amount can be removed. 
             ...
             //Reduce amount.
             _amount -= amount;
         }
    } 
 
