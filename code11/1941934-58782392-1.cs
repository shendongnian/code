    using System;
    
    namespace Compound
    {
        public class CompoundClass
        {
    
            private double balance;
            public int value { get; private set; }
    
            public CompoundClass()
            {   
                //Balance with a big B is nowhere in context
                Balance = value;
            }
    
    
            public double Balance
            {
                get
                {
                    return balance;
                }
                private set
                {
                    if (value > 0)
                    {
                        balance = value;
                    }
                }
            }
           
            //As remarked by somebody else, this function does nothing. Without return or out parameter, interest rate will stay at nothing.
            public void Rate(double interestRate)
            {
              interestRate = value / 100;
    
            }
    
            //The naming of this variable is bad. Did you mean "Amoung of Months"?
            //Also as someone else pointed out, you do not return or otherwise persist this value
            public void Years(double annualAmount)
            {
    
             annualAmount = value * 12;
    
    
            }
            //Method does not return anything.
            //accountBalance is a local value and will not persist
            public void addMethod(double accountBalance)
            {
                for (int i = 1; i < annualAmount + 1; i++)
                {
                    //Avoid putting that much stuff into 1 line. It really messes with your ability to debug
                    //1-2 operations + 1 assignment to a temporary variable per line
                    //Anything more and you will have serious issues debugging this
                    accountBalance = balance * Math.Pow(1 + interestRate / annualAmount, annualAmount * i);
    
                }
            }
        }
    }
