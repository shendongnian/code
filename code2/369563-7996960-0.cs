    namespace Shipping.Models
    {
        class CommonOrderHeader
        {
            public bool IsFulfilled { get; set; }
        }
    }
    
    namespace Shipping.Models.fnShip
    {
        class OrderHeader : CommonOrderHeader
        {
    
        }
    }
    
    namespace Shipping.Models.esShip
    {
        class OrderHeader : CommonOrderHeader
        {
            
        }
    }
