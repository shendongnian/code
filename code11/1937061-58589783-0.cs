    public class CPO : PO
    {
      private string poNumber;
      private Dictionary<string, object> invalidFields = new Dictionary<string, object>();
    
      public override Dictionary<string, object> InvalidFields { get => invalidFields; }
      public override PONumber
      {
        get 
        {
          return poNumber;
        }
        set 
        {
          if (!ValidatePONumber(value)) InvalidFields.Add("CPO Number", value);
          poNumber = value;
        }
      }
    }
