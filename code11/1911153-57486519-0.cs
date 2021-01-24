    var submissions = _context.Submissions
        .Where(s => s.ReviewRoundId == reviewRoundId && s.PeerGroup == null)
        .Select(s => {Submissionid = s.Id, s.SudentId).ToList();
    
    foreach(var submission in submissions)
    {
        var peerGroup = new PeerGroup{ SubmissionId = s.SubmissionId };
        _context.PeerGroups.Add(peerGroup);
    
        var unassignedUserIds = _context.ApplicationUsers
            .Where(u => u.Submissions.Any(s => s.ReviewRoundId == reviewRoundId
                && u.Id != submission.StudentId)
            .OrderBy(u => u.PeerGroupMemberships.Count(pg => pg.PeerGroup.Submission.ReviewRoundId == reviewRoundId))
            .Select(u => Id)
            .Take(groupSize);
    
        foreach(var userId in unassignedUserIds)
        {
            var groupMembership = new PeerGroupMembership { UserId = userId.ToString(), PeerGroup = peerGroup };
            _context.PeerGroupMemberships.Add(groupMemberShip);
        }
    }
    _context.SaveChanges();
