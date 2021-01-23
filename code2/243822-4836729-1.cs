    for (int i = 0; i < leastAbstractions.Count; i++)
     {
         int copy = i;
         Task.Factory.StartNew((object state) =>
         {
             this.Authenticate(new HighFragment(leastAbstractions[copy]))
                                         .Reactivate();
         }, TaskCreationOptions.PreferFairness);
     }
