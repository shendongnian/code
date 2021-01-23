    ctx.Comments
       .Include("CommentType")
       .Include("Owner")
       .Include("Message")
       .Where(c => c.Message.RID == messageId && c => c.CommentType.Id == commentTypeId)
       .ToList();
