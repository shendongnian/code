    var dto = ctx.Messages
              .Where(whereclause)
              .Select(m=> new DTOTYPE
                             {Id = m.Id, 
                              Content= m.Content, 
                              SenderId = m.SenderUser.Id, 
                              SenderImage = m.SenderUser.UserProfile.Image, 
                              SenderImageId = m.SenderUser.UserProfile.ImageId}) 
                             //more fields if you need any
