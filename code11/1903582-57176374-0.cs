    public class Inventory
    {
        public int id {get;set;}
        [ConcurrencyCheck]
        public int availQty {get;set;}
    }
    try
    {
        await _context.SaveChangesAsync();
    }
    catch(DbUpdateConcurrencyException)
    {
        //TODO: reread value, updated by another request, from database and decrement it again
    }
