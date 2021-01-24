        static IEnumerable<Reason> GetReasonsGrouped(List<Reason> reasons)
        {
            var result = reasons.Where(x => x.PrimaryId == null);
            foreach (var item in result)
            {
                item.SecReason = reasons.Where(x => x.PrimaryId == item.Id)
                                        .Select(x => new SecondryReason()
                                                          { Id = x.Id,
                                                            ReasonName = x.ReasonName,
                                                            PrimaryReasonId = item.Id
                                                           })
                                        .ToList();
            }
            return result;
        }
