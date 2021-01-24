    Task<IList<ChatParticipant>> GetParticipants(int chatId, int excludeUserId)
    { 
        var chatParticipants = await Context.ChatParticipant
            .Include(x => x.Chat)
            .Include(x => x.Participant)
            .Where(c => c.ParticipantId != excludeUserId
                && !Context.BlockedParticipant.Any(b => 
                     b.BlockedId == excludeUserId && b.Blocker.Id == c.ParticipantId))
            .ToListAsync();
        return chatPaticipants;
    }
