    Decimal ParseNumerString(string s)
    {
        Decimal value=0;
        Decimal multiplier=1;
        bool decimalPart=false;
        foreach(char c in s)
        {
          if(IsDigit(c))
          {
            int i=ParseDigit(c);
            if(!decimalPart)
            {
              value=value*10+i;
            }
            else
            {
             muliplier/=10;
             value=value+multiplier*i;
            }
          if(c=='.')
            decimapPart=true;
          }
          return value;
    }
