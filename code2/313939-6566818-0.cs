    public class Warehouse
    {
        private int stockCount = 0;
        private object stockSynch = new object();
       public void DecrementStock ()
       {
           lock(stockSynch)
           {
              if ( stockCount > 0 )
                stockCount--;
              Debug.Assert ( stockCount >= 0 )
           }
        }
        public void IncrementStock()
        {
            lock(stockSynch)
            {
              stockCount ++;
            }
        }
     }
