    class Program 
    {
        static void Main(string[] args)
        {
            List<OOItem> oo = new List<OOItem>();
            
            oo.Add( new OOItem() { DateActive = DateTime.Now.AddSeconds(-31) });
            lock(LockObj)
            {
                  foreach( var item in oo.Where( ooItem => ooItem.DateActive.AddSeconds(30) < DateTime.Now  ).ToArray())
                  {
                     oo.Remove(item);
                  } 
            }
            Debug.Assert( oo.Count ==  0);
        }
    }
    public class OOItem
    {
        public DateTime DateActive { get; set; }
    }
