    public class employee
    {
      public bool isContractEmployee
      { get; set;}
    
      public int NoofHR
      {get; set;}
    
      
      public  float CalCulatePayroll()
      {
        if(this.isContractEmployee)
        {
          //calculate sal on based hr
        }
        else
        {
          //calculate regurlare sal
        }
      }
    }
