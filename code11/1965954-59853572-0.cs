    var result = _participantRepo.AsQueryable().Where(x => x.Id == ParticipantId).SelectMany(x => 
        x.Relations).Where(x => x.UserId != AppUserId).Select(r => new RelationVM
                        {
                            IsOwner = r.UserId == participant.CreatedByUserId,
                            FirstName = r.FirstName,
                            LastName = r.LastName,
                            Email = r.Email,
                            UserId = r.UserId,
                            RelationType = r.RelationType,
                            Role = r.Role,
                            IsAccepted = r.IsAccepted,
                            AvatarUrl = r.AvatarUrl,
                            CreatedUtc = r.CreatedUtc
                        }).Reverse().OrderBy(g => g.CreatedUtc).ToList();
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderby?view=netframework-4.8
  [2]: https://stackoverflow.com/questions/38079586/linq-deferred-or-immediate-execution
