    int Add(int a, int b)
    {
          int result = 0,
              carry = a & b;
    
          if (Convert.ToBoolean(carry))
          {
              result = a ^ b;
              carry = carry << 1;
    
              result = add(carry, result);
          }
          else
          {
              result = a ^ b;
          }
    
          return result;
    }
