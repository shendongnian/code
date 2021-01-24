    var results = _context.ReviewRounds
        .Where(rr => rr.Id == reviewRoundId)
        .Select(rr => new ReviewRoundDTO_student
        {
            Id = rr.Id,
            SubmissionId = rr.Submissions
               .Where(s => s.StudentId == currentUser.Id)
               .Select(s => s.Id)
               .FirstOrDefault(),
            Peers = rr.Submissions
                .Where(s => s.StudentId == currentUser.Id)
                .Take(1)
                .SelectMany(s => s.PeerGroup.PeerGroupMemberships)
                .Select(m => new ApplicationUserDto
                {
                    FullName = m.User.FullName,
                    Id = m.UserId
                })
                .ToList(),
       })
       .FirstOrDefault();
