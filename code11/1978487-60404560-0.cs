    var chatParticipants = Context.ChatParticipant
                   .Include(x => x.Chat)
                   .Include(x => x.Participant)
                   .Where(c => c.ParticipantId != excludeUserId);
    var blockers = Context.BlockedParticipant
        .Include(x => x.Blocker)
        .Where(c => c.BlockedId == excludeUserId)
        .Select(x => x.Blocker);
    var ans = from cp in chatParticipants
              join bp in blockers on cp.ParticipantId equals bp.Id into bpj
              where !bpj.Any()
              select cp;
