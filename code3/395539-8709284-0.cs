    public class APIHits {
        public int hits { get; private set; }
        private DateTime minute = DateTime.Now();
      
        public bool AddHit()
        {
            if (hits < 300) {
                hits++;
                return true;
            }
            else
            {
                if (DateTime.Now() > minute.AddSeconds(60)) 
                {
                    //60 seconds later
                    minute = DateTime.Now();
                    hits = 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
       
