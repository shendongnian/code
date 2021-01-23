    bool IsUserInGroup(int groupId, int user1Id, int user2Id)
    {
     using (var db = new Model1Container())
     {
      return ((
       from ug1 in db.UserGroup
       from ug2 in db.UserGroup
       join user in db.UserTable on new { a = ug1.UserId, b = user1Id } equals new { a = user.UserId, b = user.UserId }
       join gr in db.GroupTable on new { a = ug2.GroupId, b = groupId } equals new { a = gr.GroupId, b = gr.GroupId }
       select new { ug1, ug2 })
      .FirstOrDefault()) != null;
     }
    }
