    bool IsUserInGroup(int groupId, int userId)
    {
     using (var db = new Model1Container())
     {
      return ((from ug in db.UserGroup
         join user in db.UserTable on new { a = ug.UserId, b = userId } equals new { a = user.UserId, b = user.UserId }
         join gr in db.GroupTable on new { a = ug.GroupId, b = groupId } equals new { a = gr.GroupId, b = gr.GroupId }
         select ug)
      .FirstOrDefault()) != null;
     }
    }
    
    bool IsUsersInGroup(int groupId, int user1Id, int user2Id)
    {
     return IsUserInGroup(groupId, user1Id) && IsUserInGroup(groupId, user2Id);
    }
