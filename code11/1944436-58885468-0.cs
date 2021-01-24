       LearningActionDiscussions = s.GeneralComments
                                .Where(c=> c is LearningActionComment)
                                .OfType<LearningActionComment>()
                                .GroupBy(c => c.UserId)
                                .Select(fc => new ApplicationUserDto
                                {
                                    Id = fc.Key,
                                    FullName = fc.Select(a => a.User.FullName).ElementAt(0),
                                    Count = fc.Count()
                                })
