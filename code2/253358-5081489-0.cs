    IQueryable<Case> cases; // this is obviously attached to a context and able to access data)
    var broken = cases
       .Where(c => c.MeetingCases
                    .Where(mc => mc.ExpectedStartDateTime <= DateTime.Now)
                    .Any(m => !m.MeetingCaseOutcomes.Any()));
