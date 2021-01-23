    var query1 = (from d in db.DiaryPosts
                  where d.UserID = 1
                  select new { 
                    UserID = d.UserID
                    Content = d.Content
                    UpdateTime = d.UpdateTime 
                  }).ToList();
    var query2 = (from d in db.DiaryPosts
                  join f in db.Friends
                  on d.UserId = f.FriendId
                  where f.UserId = 1
                  select new { 
                    UserID = d.UserID
                    Content = d.Content
                    UpdateTime = d.UpdateTime 
                  }).ToList();
    var query3 = (from d in db.DiaryPosts
                  join f in db.Followers
                  on d.UserId = f.FollowerID
                  where f.UserId = 1
                  select new { 
                    UserID = d.UserID
                    Content = d.Content
                    UpdateTime = d.UpdateTime 
                  }).ToList();
    
    var myunionQuery = query1.Union(query2).Union(query3).OrderBy(d => d.UpdateTime);
