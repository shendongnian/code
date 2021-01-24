    public bool test(ulong num)
          { var sqrt = Math.Sqrt(num);
            double dbl = Convert.ToDouble(sqrt);
            long dblint = Convert.ToInt64(sqrt);
            if (dbl == dblint)
            {
                return true;
            }        
            return false;
        }
