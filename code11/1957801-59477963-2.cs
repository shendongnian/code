    private void TimerElapsed(object sender, ElapsedEventArgs e)
     {
        ReceivePost receivePost = new ReceivePost()
        {
           Status = "pending"
        };
                
        using(UserDbContext dbContext = new UserDbContext())
        {
            dbContext.receivePosts.Add(receivePost);
            dbContext.SaveChanges();
        }
                
        // string[] lines = new string[] { DateTime.Now.ToString() };
       // File.AppendAllLines(@"F:\nepal.txt", lines);
    }
