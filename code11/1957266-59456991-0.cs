    public static int ControlNumber(ref int Q)
        {
            if (//some condition)
            {
              return some digit;
            }
            else
            {
                Q += 1;
                return ControlNumber(ref Q);
            }
        }
