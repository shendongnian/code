        public class Bet
        {
            #region instance members
    
            public decimal Amount
            {
                get;
                set;
            }
    
            public string Description
            {
                get;
                set;
            }
    
            public void Payout()
            {
                // do something
            }
    
            #endregion
    
            #region static members
    
            public static Bet Empty
            {
                get
                {
                    Bet b = new Bet();
                    b.Amount = 0M;
                    b.Description = "Default Empty Bet";
    
                    return b;
                }
            }
    
            #endregion
        }
