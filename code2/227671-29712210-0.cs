        UserTopic existingUserTopic = _context.UserTopics
                .Include(ut => ut.Topic)
                .FirstOrDefault(t => t.UserId == currentUserId && t.TopicId == topicId);
            if (existingUserTopic != null)
            {
                var entry = _context.Entry(existingUserTopic);
                entry.State = EntityState.Deleted;
                 
                if (existingUserTopic.Topic.UserCreated) 
                {
                    var topicEntry = _context.Entry(existingUserTopic.Topic);
                    entry.State = EntityState.Deleted;
                }
                await _context.SaveChangesAsync();
            }
