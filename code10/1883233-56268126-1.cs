    Class Employee
    {
       public decimal MyBonus = 0.0m;
       public virtual void CalculateBonus() 
       {
          MyBonus = MySales * .13m;
       }
    }
    
    class SalesPerson : Employee 
    {
    }
    class PTSalesPerson : SalesPerson
    {
       public override void CalculateBonus() 
       {
          // go do the NORMAL Calculation at the EMPLOYEE Level
          base.CalculateBonus();
          // Now continue from that... As Part-Time sales person,
          // they get 1/4 of that rate.  So take whatever the result
          // WAS and multiply by .25
          MyBonus = MyBonus * .25m;
       }
    }
