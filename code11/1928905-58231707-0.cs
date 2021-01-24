    var audit = new Audit
        {
            Data = model.Data,
            UserId = user.Id,
            IpAddress = Helper.GetClientIp(Request),
            Session = sid != null ? sid : ItsMyChance.Entities.Entities.SessionId.Create(scoreModel.UserName, scoreModel.GameId)
        };
