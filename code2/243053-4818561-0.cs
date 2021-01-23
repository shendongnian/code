    class Employee
    {
    
       public Currency Currency
       {
        get
         {
           return m_Currency;
          }
       }
    
       public string CurrencyName
       {
         get
           {
            return this.Currency.Name;
           }
       }
    }
