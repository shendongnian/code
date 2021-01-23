    class HitCountCache
    {
       class Counter 
       {
           public unsigned int count {get;set}
           public accountid {get;set}
       };
    
       private Dictionary<accountType, Counter> _counts = new Dictionary<...>();
       private Object _lock= new Object();
    
       // invoke this on every call
       //
       void IncrementAccountId (accountId)
       {
          Counter count;
          lock(_lock) 
          {
             if (_counts.TryGetValue (accountId, out count))
             {
                ++count.count;
             }
             else
             {
                _counts.Add (accountId, 
                    new Counter {accountId = accountId; count=0});
             }
          }
       } 
    
       // Schedule this to be invoked every X minutes
       //
       void Save (SqlConnection conn)
       {
          Counter[]  counts;
        
          // Snap the counts, under lock
          //
          lock(_counts)
          {
              counts = _counts.ToArray();
              _counts.Clear();
          }
    
          // Lock is released, can do DB work
          //
          foreach(Counter c in counts)
          {
              SqlCommand cmd = new SqlCommand(
                     @"Update table set count+=@count where accountId=@accountId", 
                     conn);
              cmd.Parameters.AddWithValue("@count", c.count);
              cmd.Parameters.AddWithValue("@accountId", accountId);
              cmd.ExecuteNoQuery();
          }
       } 
    }
