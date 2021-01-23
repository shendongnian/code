    class OrderStatus
    
       public static readonly OrderStatus ClosedStatus = new OrderStatus("C");
    
       public static readonly OrderStatus OpenStatus = new OrderStatus("O");
    
       public static readonly OrderStatus PendingStatus = new OrderStatus("P");
    
       public static OrderStatus FromCode(string code)
       {
          if (code == "C")
             return ClosedStatus;
          else if (code == "O")
             return OpenStatus;
          else if (code == "P")
             return PendingStatus;
          else
             throw something;
       }
    
       private string _code;
    
       private OrderStatus(string code)
       {
          // private so cannot be created externally
          _code = code;
       }
    
       public string StatusCode { get { return code; } }
       // etc, etc.  Helpful to make ToString() return the inner status code.
       
    }
