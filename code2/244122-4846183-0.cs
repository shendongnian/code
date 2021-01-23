    public string SalaryRange
    {
       get
       {
          if (salary <= LowRange)
          {
             return "Low";
          }
          if (salary <= MiddleRange)
          {
             return "Middle";
          }
          return "High";
       }
    }
