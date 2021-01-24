    using(var ctx = new DataReviewContext2())
    {
       foreach(var value in values)
       {
           value.Username = user;
           value.Changed = DateTime.Now;
           ctx.ChangeLog.Add(value);
       }
       ctx.SaveChanges();
       
       // Add this to get all userIs 
       var Ids = values.Select(c=>c.UserId).ToList();
    }
