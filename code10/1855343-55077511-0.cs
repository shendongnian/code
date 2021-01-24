    List<Models.ChatMessageModel> list = (from dbModel in db.ChatMessages
            join a in db.Users on dbModel.UserId equals a.UserId
            select new Models.ChatMessageModel
            {
               User = new Models.UserModel
               {
                   UserId = dbModel.UserId,
                   UserName = a.UserName
               },
               UserId = a.UserId,
               DateSent = dbModel.DateSent,
               ChatMessage = dbModel.ChatMessage,
               ChatMessageId = dbModel.ChatMessageId
            }).ToList();
