    var res = context.Entities
                 .OfType<ChatRoom>()
                 .Include("Participants") // I think this could be removed.
                 .Select(r => new
                              {
                                 Room = r,
                                 Messages = r.ChatMessages.Count(),
                                 Participants = r.Participants
                              })
                 .FirstOrDefault(c => c.Room.Id == id);
