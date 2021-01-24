   public static Expression<Func<UserA, UserBlogStats>> AsUserBlogStats
            => u => new UserBlogStats(u.Id, u.BlogPosts.Count);
   public static Expression<Func<UserA, UserProfile>> AsUserUserProfile
   {
      get
      {
         var userBlogStatsExpr = AsUserBlogStats; // local var required in Linqkit
         return u => new UserProfile(u.Id, u.Name, userBlogStatsExpr .Invoke(u));
      }
   }
and 
db.Users.AsExpandable().Select(AsUserUserProfile)
