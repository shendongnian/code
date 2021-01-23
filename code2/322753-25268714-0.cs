    public double Double_fromObject(object obj)
        {
          double dNum = 0.0;
          if (obj.ToString() != string.Empty) // the Convert fails when ""
          {
            try
            {
              dNum = Convert.ToDouble(obj);
            }
            catch (SystemException sex)
            {
              // this class's error string
              LastError = sex.Message;
            }
          }
    
          return (dNum);
        }
