    class Konto
    {
       public int Money {private set; get;}
       public Konto(int initialAmount)
       {
           Money = initialAmount;
       }
    
       public int Withdrawal(amount)
       {
          Money -= amount;
          return Money;
       }
       public void Deposit(int amount)
       {
          Money += amount;
       }
    }
