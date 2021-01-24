//Model
public class Address 
    {
        public string AHouseNumber 
        public string BHouseNumber 
        public string CHouseNumber 
(...)
You could do a simple concat:
    await db.Addresses
      .Select( a=> new { Address = AHouseNumber + BHouseNumber + CHouseNumber } )
      .ToListAsync(); 
### 2b. Run custom query
