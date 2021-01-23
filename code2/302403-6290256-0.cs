    StringBuilder sb = new StringBuilder();
    sb.Append("SELECT u.Name,t.ThreadTitle,t.Date, t.Views,t.Replies,p.Theme,p.Topics,t.PageNumber ");
    sb.Append("FROM Users AS u ");
    sb.Append("INNER JOIN Threads AS t ON u.UserID=t.UserID ");
    sb.Append("INNER JOIN Topics AS p ON p.TopicID=t.TopicID ");
    sb.Append("WHERE u.UserID=@UserID ");
    sb.Append("ORDER BY t.Date"); 
