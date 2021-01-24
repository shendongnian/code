     List<ApplicationUserDto> peers = _context.ApplicationUsers
            .Select(m => new ApplicationUserDto
              {
                  Id = m.Id,
                  MyCount = m.GroupMemberships
                             .Count(pg => pg.StudentGroup.ReviewRoundId == reviewRoundId && !(pg.StudentGroup is PeerStudentGroup))
              }).ToList();
