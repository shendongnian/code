    public class work()
    {
        public void setValue()
        {
           var context = await _context.firstordefaultasync(....);
           context......
           //Work with that context
           ...save context...
        }
    }
